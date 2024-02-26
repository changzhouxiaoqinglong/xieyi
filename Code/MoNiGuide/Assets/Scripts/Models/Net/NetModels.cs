
using System.Collections.Generic;

namespace Server.Models.Net
{

    /// <summary>
    /// 通用数据传输模板
    /// </summary>
    public class NetData
    {
        /// <summary>
        /// 协议号
        /// </summary>
        public int ProtocolCode;

        /// <summary>
        /// 机号
        /// </summary>
        public int MachineId;

        /// <summary>
        /// 席位号
        /// </summary>
        public int SeatId;

        /// <summary>
        /// 消息内容
        /// </summary>
        public string Msg;
    }

    public class LoginModel
    {
        public string UserName;

        public string PassWord;

        public int CarId;
    }

    public class LoginRes : ResBase
    {
        public string UserName;
    }

    /// <summary>
    /// 退出登录
    /// </summary>
    public class ExitLoginModel
    {
        public string UserName;
    }

    public class StartTrainModel
    {
        public List<TrainMachineData> TrainMachineDatas;
    }

    /// <summary>
    /// 获得成绩
    /// </summary>
    public class GetScoreModel
    {
        /// <summary>
        /// 得分
        /// </summary>
        public float Score;

        /// <summary>
        /// 扣分项
        /// </summary>
        public List<DeductItem> DeductItems;
    }

    /// <summary>
    /// 扣分项
    /// </summary>
    public class DeductItem
    {
        /// <summary>
        /// 扣分项描述
        /// </summary>
        public string Desc;

        /// <summary>
        /// 扣分数
        /// </summary>
        public float DeductScore;
    }
}


/// <summary>
/// 导控训练进程
/// </summary>
public enum GuideProcessType
{
    Pause = 1,
    Continue,
    End,
}

/// <summary>
/// 导控控制训练进程
/// </summary>
public class GuideProcessCtrModel
{
    public GuideProcessType Operate;
}