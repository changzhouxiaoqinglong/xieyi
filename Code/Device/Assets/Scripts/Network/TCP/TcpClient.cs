using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
public enum ConnectStatus
{
    /// <summary>
    /// 未连接
    /// </summary>
    Disconnected,

    /// <summary>
    /// 正在连接中
    /// </summary>
    Connecting,

    /// <summary>
    /// 已连接
    /// </summary>
    Connected,
}

/// <summary>
/// tcp客户端
/// </summary>
public class TcpClient : IClient
{
    private const string TAG = "[TcpClient]:";
    public Socket socket;

    /// <summary>
    /// 服务器 ip 和 端口
    /// </summary>
    private IPEndPoint ipEndPoint;

    /// <summary>
    /// 当前连接状态
    /// </summary>
    public ConnectStatus curStatus = ConnectStatus.Disconnected;

    /// <summary>
    /// 发送处理
    /// </summary>
    private TcpSendHandler sendHandler;

    /// <summary>
    /// 接收处理
    /// </summary>
    private TcpReceiveHandler receiveHandler;

    /// <summary>
    /// 心跳处理
    /// </summary>
    private TcpHeartBeat heartBeat;

    /// <summary>
    /// 连接的服务器类型
    /// </summary>
    public ServerType ServerType { get; set; }

    public TcpClient(string ip, int port, ServerType ServerType)
    {
        ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
        this.ServerType = ServerType;
    }

    private void SetConnectStatus(ConnectStatus status)
    {
        curStatus = status;
    }

    /// <summary>
    /// 连接服务器
    /// </summary>
    public void ConnectServer()
    {
        if (IsConnected())
        {
            Logger.LogWarning(TAG + "Connect fail, already connected!");
            return;
        }
        if (curStatus == ConnectStatus.Connecting)
        {
            Logger.LogWarning(TAG + "Connect fail, is Connecting");
            return;
        }
        if (socket == null)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sendHandler = new TcpSendHandler(socket);
            receiveHandler = new TcpReceiveHandler(this);
            heartBeat = new TcpHeartBeat(this);
        }
        SetConnectStatus(ConnectStatus.Connecting);
        try
        {
            //开始连接
            socket.BeginConnect(ipEndPoint, ConnectCallBack, null);
        }
        catch (Exception e)
        {
            SetConnectStatus(ConnectStatus.Disconnected);
            Logger.LogWarning(TAG + "Connect fail!!!" + e.ToString());
        }
    }

    private void ConnectCallBack(IAsyncResult iar)
    {
        try
        {
            socket.EndConnect(iar);
            Logger.LogDebug(TAG + "Connect success:" + ipEndPoint.Address.ToString());
            SetConnectStatus(ConnectStatus.Connected);
        }
        catch (Exception e)
        {
            SetConnectStatus(ConnectStatus.Disconnected);
            Logger.LogWarning(TAG + "Connect fail!!!" + e.ToString());
        }
        if (IsConnected())
        {
            heartBeat.ResetTimer();
            //开始心跳
            heartBeat.StartHeartBeat();
            //开始心跳计时
            heartBeat.StartRevTimer();
            //开始接收消息
            receiveHandler.StartReceive();
            //发送初始数据
            InitModel initModel = new InitModel();
            NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(initModel), NetProtocolCode.INIT_MSG);
        }
    }

    /// <summary>
    /// 收到网络数据（一般收到数据 都用事件派发 在主线程上处理 除非特殊的网络相关逻辑 直接在这里处理）
    /// </summary>
    public void OnReceiveNetData(NetData netData)
    {
        switch (netData.ProtocolCode)
        {
            case NetProtocolCode.HEART_BEAT:
                //重置心跳计时 因为计时都是在线程里做的，如果把重置逻辑放到主线程，
                //会导致如果调了unity的暂停逻辑，心跳计时不会被重置 导致超时断开连接
                heartBeat.ResetTimer();
                break;
            default:
                break;
        }
    }

    public bool IsConnected()
    {
        return curStatus == ConnectStatus.Connected;
    }

    public void DisConnect()
    {
        if (IsConnected())
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception)
            {
            }
            SetConnectStatus(ConnectStatus.Disconnected);
        }
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    public void SendMsg(string message, int protocolCode)
    {
        NetData data = new NetData(protocolCode, message);
        string jsonMsg = JsonTool.ToJson(data);
        Logger.LogDebug(TAG + "SendMsg:" + jsonMsg);
        sendHandler.AddSendMsg(TcpMessageHandler.PackMessage(jsonMsg));
    }
}
