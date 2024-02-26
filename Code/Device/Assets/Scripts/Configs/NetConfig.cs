/// <summary>
/// 网络配置
/// </summary>
public class NetConfig : ConfigBase<NetConfig>
{
    /// <summary>
    /// 导控服务器 ip地址
    /// </summary>
    public static string GUIDE_IP;

    /// <summary>
    /// 导控服务器 端口号
    /// </summary>
    public static int GUIDE_PORT;

    /// <summary>
    /// TCP连接 消息包头的大小 包头保存包体大小 int型 占4位
    /// </summary>
    public static int TCP_MESSAGE_HEAD_LEN;

    /// <summary>
    /// 心跳上报间隔 ms
    /// </summary>
    public static int HEART_BEAT_OFFTIME;

    /// <summary>
    /// 断开连接 心跳超时时间 s
    /// </summary>
    public static int HEART_BEAT_TIME_OUT;

    public static void InitConfig()
    {
        ParseConfigByReflection("NetConfig.cfg");
    }
}
