using System.Collections.Generic;
using UnityEngine;
using static EventDispatcher;

/// <summary>
/// 连接的服务器
/// </summary>
public enum ServerType
{
    /// <summary>
    /// 本地服务器连接
    /// </summary>
    LocalServer,
}

public class NetManager : MonoSingleTon<NetManager>
{
    private const string TAG = "[NetManager]:";

    /// <summary>
    /// 当前的网络连接
    /// </summary>
    private Dictionary<ServerType, IClient> clients = new Dictionary<ServerType, IClient>();

    /// <summary>
    /// 添加网络连接
    /// </summary>
    private void AddClient(ServerType type, IClient client)
    {
        lock (clients)
        {
            if (clients.ContainsKey(type))
            {
                Logger.LogWarning(TAG + "Add Client Fail  Have Client");
                client.DisConnect();
                return;
            }
            clients[type] = client;
        }
    }

    /// <summary>
    /// 建立连接
    /// </summary>
    public void ConnectServer(ServerType type)
    {
        switch (type)
        {
            case ServerType.LocalServer:
                TcpClient sysClient = new TcpClient(NetConfig.GUIDE_IP, NetConfig.GUIDE_PORT, ServerType.LocalServer);
                sysClient.ConnectServer();
                AddClient(type, sysClient);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 对应服务器是否是连接状态
    /// </summary>
    public bool IsConnected(ServerType type)
    {
        return clients.ContainsKey(type) && clients[type].IsConnected();
    }
    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="type">服务器</param>
    /// <param name="message">消息内容</param>
    /// <param name="protocolCode">协议号</param>
    public void SendMsg(ServerType type, string message, int protocolCode)
    {
        if (clients.ContainsKey(type))
        {
            clients[type].SendMsg(message, protocolCode);
        }
        else
        {
            Logger.LogWarning("Servertyp : " + type + "    not connect can not SendMsg");
        }
    }

    #region  网络事件监听
    /// <summary>
    /// 添加网络数据接收监听
    /// </summary>
    /// <param name="type">对应服务器</param>
    /// <param name="protocolCode">监听的协议号</param>
    /// /// <param name="handler">监听事件</param>
    public void AddNetMsgEventListener(ServerType type, int protocolCode, EventHandler handler)
    {
        EventDispatcher.GetInstance().AddEventListener(GetNetMsgEventKey(type, protocolCode), handler);
    }

    /// <summary>
    /// 移除网络数据接收监听
    /// </summary>
    /// <param name="type">对应服务器</param>
    /// <param name="protocolCode">监听的协议号</param>
    /// <param name="handler">监听事件</param>
    public void RemoveNetMsgEventListener(ServerType type, int protocolCode, EventHandler handler)
    {
        EventDispatcher.GetInstance().RemoveEventListener(GetNetMsgEventKey(type, protocolCode), handler);
    }

    /// <summary>
    /// 接收到网络数据 事件派发
    /// </summary>
    public void DispatchNetMsgEvent(ServerType type, int protocolCode, IEventParam param)
    {
        EventDispatcher.GetInstance().DispatchEventMainThread(GetNetMsgEventKey(type, protocolCode), param);
    }
    #endregion

    /// <summary>
    /// 获取网络消息事件 对应的key
    /// </summary>
    /// <param name="type">对应服务器</param>
    /// <param name="protocolCode">监听的协议号</param>
    private string GetNetMsgEventKey(ServerType type, int protocolCode)
    {
        return EventNameList.ON_RECEIVE_NET_MSG + "_" + type + "_" + protocolCode;
    }

    private void OnDestroy()
    {
        foreach (var item in clients.Values)
        {
            item.DisConnect();
        }
    }
}