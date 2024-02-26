public interface IClient
{
    ServerType ServerType { get; set; }

    /// <summary>
    /// 断开连接
    /// </summary>
    void DisConnect();

    bool IsConnected();

    /// <summary>
    /// 发送消息
    /// </summary>
    void SendMsg(string message, int protocolCode);
}
