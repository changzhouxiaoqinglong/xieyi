using Server.Constant;
using Server.Event;
using Server.Models.Net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

/// <summary>
/// 服务器
/// </summary>
namespace TcpServer.Servers
{
    public class TcpServer
    {
        /// <summary>
        /// 服务器地址和端口号
        /// </summary>
        public IPEndPoint ipEndPoint;

        /// <summary>
        /// 服务器socket
        /// </summary>
        private Socket serverSocket;

        /// <summary>
        /// 当前连接的客户端
        /// </summary>
        private TcpClient client;

        /// <summary>
        /// 当前登录的用户
        /// </summary>
        private List<User> users = new List<User>();

        /// <summary>
        /// 同机号用户
        /// </summary>
        public Dictionary<int, List<User>> machineUsers = new Dictionary<int, List<User>>();

        public TcpServer(string ipAddress, int port)
        {
            ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            NetEventDispatcher.GetInstance().AddTcpMsgEventListener(NetProtocolCode.LOGIN, OnRevLoginMsg);
            //NetEventDispatcher.GetInstance().AddTcpMsgEventListener(NetProtocolCode.EXIT_LOGIN, OnRevExit);
        }

        /// <summary>
        /// 开启服务器
        /// </summary>
        public void Start()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(ipEndPoint);
            serverSocket.Listen(NetConfig.TCP_CONNECT_NUM);
            serverSocket.BeginAccept(AcceptCallBack, null);//开始异步接收数据
            Logger.LogDebug("服务器开启，开始异步接收数据");
        }

        private void AcceptCallBack(IAsyncResult iar)
        {
            Socket clientSocket = serverSocket.EndAccept(iar);
            TcpClient client = new TcpClient(clientSocket, this);
            this.client = client;
            Logger.LogDebug("客户端已连接");
            serverSocket.BeginAccept(AcceptCallBack, null);
        }

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        public void ClientDisConnect(TcpClient client)
        {
            lock (this.client)
            {
                this.client = null;
                Logger.LogDebug("客户端断开连接：");
            }
        }

        /// <summary>
        /// 接收登录消息
        /// </summary>
        private void OnRevLoginMsg(IEventParam param)
        {
            Debug.Log("收到登录消息");
            if (param is TcpReceiveEvParam tcpParam)
            {
                LoginModel loginModel = JsonTool.ToObject<LoginModel>(tcpParam.netData.Msg);
                LoginRes res = new LoginRes()
                {
                    UserName = loginModel.UserName,
                };
                Debug.Log("登陆成功  用户名：" + loginModel.UserName + "   机号：" + tcpParam.netData.MachineId + "  席位号：" + tcpParam.netData.SeatId);
                //登录成功 回发消息
                SendMsgToUser(JsonTool.ToJson(res), tcpParam.netData.ProtocolCode, tcpParam.netData.MachineId, tcpParam.netData.SeatId);
                User user = new User()
                {
                    UserName = loginModel.UserName,
                    CarId = loginModel.CarId,
                    MachineId = tcpParam.netData.MachineId,
                    SeatId = tcpParam.netData.SeatId
                };
                //增加用户
                users.Add(user);
                lock (machineUsers)
                {
                    //根据机型 补充字典数据
                    int machineId = tcpParam.netData.MachineId;
                    if (machineUsers.ContainsKey(machineId))
                    {
                        machineUsers[machineId].Add(user);
                    }
                    else
                    {
                        List<User> userList = new List<User>();
                        userList.Add(user);
                        machineUsers[machineId] = userList;
                    }
                    Debug.Log("目前机号 " + machineId + "  当前机号下登录人数为：" + machineUsers[machineId].Count);
                }
            }
        }

        /// <summary>
        /// 收到退出登录的消息
        /// </summary>
        private void OnRevExit(IEventParam param)
        {
            if (param is TcpReceiveEvParam tcpParam)
            {
                ExitLoginModel model = JsonTool.ToObject<ExitLoginModel>(tcpParam.netData.Msg);
                lock (users)
                {
                    int length = users.Count;
                    for (int i = length - 1; i >= 0; i--)
                    {
                        if (users[i].UserName == model.UserName)
                        {
                            users.RemoveAt(i);
                        }
                    }
                }
                lock (machineUsers)
                {
                    if (machineUsers.ContainsKey(tcpParam.netData.MachineId))
                    {
                        List<User> users = machineUsers[tcpParam.netData.MachineId];
                        lock (users)
                        {
                            int length = users.Count;
                            for (int i = length - 1; i >= 0; i--)
                            {
                                if (users[i].UserName == model.UserName)
                                {
                                    users.RemoveAt(i);
                                }
                            }
                        }
                    }
                }
                Debug.Log("用户退出 机号： " + tcpParam.netData.MachineId + " 用户名：" + model.UserName +
                    "当前剩余登录总人数为：" + users.Count);
                int machineLeft = machineUsers.ContainsKey(tcpParam.netData.MachineId) ? machineUsers[tcpParam.netData.MachineId].Count : 0;
                Debug.Log("当前机器剩余登录人数为： " + machineLeft);
            }
        }
        /// <summary>
        /// 发送消息给具体人
        /// </summary>
        public void SendMsgToUser(string message, int protocolCode, int machineId, int seatId)
        {
            client.SendMsg(message, protocolCode, machineId, seatId);
        }

        /// <summary>
        /// 发送给消息给对应车的所有人
        /// </summary>
        public void SendMsgToCar(string message, int protocolCode, int machineId)
        {
            client.SendMsg(message, protocolCode, machineId);
        }

        /// <summary>
        /// 发送消息给所有人
        /// </summary>
        public void SendMsgToAll(string message, int protocolCode)
        {
            foreach (var item in machineUsers)
            {
                SendMsgToCar(message, protocolCode, item.Key);
            }
        }

        public void SendMsg(NetData netData)
        {
            client.SendMsg(netData);
        }

        public void Close()
        {
            if (client != null)
            {
                client.DisConnect();
            }
            serverSocket.Close();
            serverSocket.Dispose();
        }
    }
}
