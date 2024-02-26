public interface IEventParam { }

public class StringEvParam : IEventParam
{
    public string value;
    public StringEvParam(string value)
    {
        this.value = value;
    }
}

/// <summary>
/// tcp接收消息 事件参数
/// </summary>
public class TcpReceiveEvParam : IEventParam
{
    public NetData netData;

    public TcpReceiveEvParam(NetData netData)
    {
        this.netData = netData;
    }
}
