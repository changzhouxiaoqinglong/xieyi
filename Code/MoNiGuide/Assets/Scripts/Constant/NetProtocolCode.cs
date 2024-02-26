/// <summary>
/// 网络协议号
/// </summary>
public class NetProtocolCode
{
    #region tcp

    /// <summary>
    /// 心跳包
    /// </summary>
    public const int HEART_BEAT = 0;

    /// <summary>
    /// 初始数据
    /// </summary>
    public const int INIT_MSG = 1;

    /// <summary>
    /// 登录
    /// </summary>
    public const int LOGIN = 2;

    /// <summary>
    /// 下发任务环境
    /// </summary>
    public const int TASK_ENV = 4;

    /// <summary>
    /// 训练开始
    /// </summary>
    public const int TRAIN_START = 5;

    /// <summary>
    /// 操作毒剂报警器
    /// </summary>
    public const int POISON_ALARM_OP = 2011;

    /// <summary>
    /// 毒剂报警器 进样情况
    /// </summary>
    public const int POISON_IN_STATUS = 7;

    /// <summary>
    /// 温湿度风向风速下发
    /// </summary>
    public const int METEOR_ENV = 104;

    /// <summary>
    /// 结束训练
    /// </summary>
    public const int END = 9;

    /// <summary>
    /// 北斗数据  经纬度 时间
    /// </summary>
    public const int BEIDOU_DATA = 103;

    /// <summary>
    /// 操作辐射仪
    /// </summary>
    public const int RADIOME_OP = 2021;

    /// <summary>
    /// 设置辐射剂量率阈值
    /// </summary>
    public const int SET_RADIOM_RATE_THRESHOLD = 2022;

    /// <summary>
    /// 设置辐射 累计剂量率阈值
    /// </summary>
    public const int SET_TT_RADIOM_RATE_THRESHOLD = 2023;

    /// <summary>
    /// 发送辐射剂量率
    /// </summary>
    public const int SEND_RADIOM_RATE = 101;

    /// <summary>
    /// 操作电源
    /// </summary>
    public const int POWER_OP = 2041;

    /// <summary>
    /// 操作北斗
    /// </summary>
    public const int BEIDOU_OP = 2051;

    /// <summary>
    /// 操作气象器件
    /// </summary>
    public const int METEOR_OP = 2052;

    /// <summary>
    /// 插旗子 通知导控
    /// </summary>
    public const int FLAG = 17;

    /// <summary>
    /// 操作车载侦毒器
    /// </summary>
    public const int OP_CAR_DETECT_POISON = 2032;

    /// <summary>
    /// 下车
    /// </summary>
    public const int OUT_CAR = 19;

    /// <summary>
    /// 下车结果
    /// </summary>
    public const int OUT_CAR_RES = 20;

    /// <summary>
    /// 上车
    /// </summary>
    public const int IN_CAR = 21;

    /// <summary>
    /// 上车结果
    /// </summary>
    public const int IN_CAR_RES = 22;

    /// <summary>
    /// 防护
    /// </summary>
    public const int PROTECT = 23;

    /// <summary>
    /// 插旗子 通知驾驶位 3D场景内插旗
    /// </summary>
    public const int FLAG_TO_DRIVER = 24;

    /// <summary>
    /// 设置抽气时间
    /// </summary>
    public const int SET_CAR_POIS_GAS_TIME = 2031;

    /// <summary>
    /// 成绩下发
    /// </summary>
    public const int GET_SCORE = 26;

    /// <summary>
    /// 车长命令
    /// </summary>
    public const int MASTER_INSTRUCT = 27;

    /// <summary>
    /// 导控控制训练进程
    /// </summary>
    public const int GUIDE_PROCESS_CTR = 33;

    #endregion
}
