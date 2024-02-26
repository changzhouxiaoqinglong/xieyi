using Server.Constant;
using Server.Event;
using Server.Models.Net;
using Server.Servers;
using System.Net.Sockets;

namespace TcpServer.Servers
{
    /// <summary>
    /// 连接的客户端
    /// </summary>
    public class TcpClient
    {
        /// <summary>
        /// 客户端socket
        /// </summary>
        public Socket clientSocket;

        /// <summary>
        /// 服务器socket
        /// </summary>
        public TcpServer server;

        /// <summary>
        /// 接收处理
        /// </summary>
        private TcpReceiveHandler receiveHandler;

        /// <summary>
        /// 发送处理
        /// </summary>
        private TcpSendHandler sendHandler;

        /// <summary>
        /// 客户端心跳处理
        /// </summary>
        private TcpHeartBeat heartBeat;

        public TcpClient(Socket clientSocket, TcpServer server)
        {
            this.clientSocket = clientSocket;
            this.server = server;
            receiveHandler = new TcpReceiveHandler(this);
            receiveHandler.StartReceive();
            sendHandler = new TcpSendHandler(this);
            heartBeat = new TcpHeartBeat(this);
            NetEventDispatcher.GetInstance().AddTcpMsgEventListener(NetProtocolCode.HEART_BEAT, OnRevHeartBeat);
            //开始心跳计时
            heartBeat.StartRevTimer();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">发送的内容</param>
        /// <param name="protocolCode">协议号</param>
        public void SendMsg(string message, int protocolCode, int machineId = 0, int seatId = 0)
        {
            NetData data = new NetData()
            {
                Msg = message,
                ProtocolCode = protocolCode,
                MachineId = machineId,
                SeatId = seatId
            };
            SendMsg(data);
        }

        public void SendMsg(NetData data)
        {
            string sendStr = JsonTool.ToJson(data);
            Logger.LogDebug("SendMsg:" + sendStr);
            sendHandler.AddSendMsg(TcpMessageHandler.PackMessage(sendStr));
        }

        public bool IsConnected()
        {
            return clientSocket != null && clientSocket.Connected;
        }

        /// <summary>
        /// 收到客户端传来的心跳包
        /// </summary>
        private void OnRevHeartBeat(IEventParam param)
        {
            //回发心跳包
            SendMsg("", NetProtocolCode.HEART_BEAT);
            heartBeat.ResetTimer();
        }

        /// <summary>
        /// 客户端断开连接
        /// </summary>
        public void DisConnect()
        {
            Logger.LogDebug("客户端断开连接");
            clientSocket.Close();
            server.ClientDisConnect(this);
            clientSocket.Dispose();
            //if (user != null)
            //{
            //    LoginManager.GetInstance().RemoveUser(user);
            //}
            NetEventDispatcher.GetInstance().RemoveTcpMsgEventListener(NetProtocolCode.HEART_BEAT, OnRevHeartBeat);
        }
    }
}
