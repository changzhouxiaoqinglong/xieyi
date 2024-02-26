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
    /// 车型
    /// </summary>
    public int CarType;

    /// <summary>
    /// 消息内容
    /// </summary>
    public string Msg;

    public NetData(int ProtocolCode, string Msg)
    {
        this.ProtocolCode = ProtocolCode;
        this.Msg = Msg;
        MachineId = AppConfig.MACHINE_ID;
        SeatId = AppConfig.SEAT_ID;
        CarType = AppConfig.CAR_ID;
    }
}

/// <summary>
/// 设备操作
/// </summary>
public class OperateDevice
{
    /// <summary>
    /// 关闭
    /// </summary>
    public const int CLOSE = 0;

    /// <summary>
    /// 打开
    /// </summary>
    public const int OPEN = 1;
}

/// <summary>
/// 客户端初始数据
/// </summary>
public class InitModel
{
    /// <summary>
    /// 软件类型 1.三维软件 2.设备管理软件
    /// </summary>
    public int EquipType = 2;
}

public class LoginModel
{
    public string UserName;

    public string PassWord;
}

public class LoginRes : ResBase
{
    public string UserName;
}

/// <summary>
/// 操作毒剂报警器
/// </summary>
public class PoisonAlarmOpModel
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}

public class TelemetrModel
{

}

/// <summary>
/// 毒剂报警器 进样情况
/// </summary>
public class PoisonInStatusModel
{
    /// <summary>
    /// 状态 0关  1开
    /// </summary>
    public int Status;
}

/// <summary>
/// 操作辐射仪
/// </summary>
public class RadiomeOpModel
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}

/// <summary>
/// 操作电源
/// </summary>
public class PowerOpModel
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}

/// <summary>
/// 操作北斗
/// </summary>
public class BeiDouOpModel
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}

/// <summary>
/// 操作气象器件
/// </summary>
public class MeteorOpModel
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}


/// <summary>
/// 操作车载侦毒器
/// </summary>
public class CarDetectPoisonOpModel
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}

#region 设备自检
/// <summary>
/// 设备类型
/// </summary>
public class DeviceType
{
    /// <summary>
    /// 毒剂报警器
    /// </summary>
    public const int POISON_ALARM = 1;

    /// <summary>
    /// 车载侦毒器
    /// </summary>
    public const int CAR_POISON_CHECK = 2;

    /// <summary>
    /// 辐射仪
    /// </summary>
    public const int RADIAMETER = 3;
}

/// <summary>
/// 设备上报自检
/// </summary>
public class DeviceCheckModel
{
    /// <summary>
    /// 设备类型
    /// </summary>
    public int Type;

    public DeviceCheckModel(int type)
    {
        Type = type;
    }
}
#endregion

/// <summary>
/// 设置剂量率阈值
/// </summary>
public class SetDoseThreshold
{
    /// <summary>
    /// 剂量率阈值
    /// </summary>
    public float DoseThreshold;
}

/// <summary>
/// 设置累计剂量率阈值
/// </summary>
public class SetTotalDoseThreshold
{
    /// <summary>
    /// 累计剂量率阈值
    /// </summary>
    public float TotalDoseThreshold;
}

/// <summary>
/// 设置剂量率
/// </summary>
public class SetDoseRateModel
{
    /// <summary>
    /// 剂量率
    /// </summary>
    public float DoseRate;
}

#region 102车载辐射仪
/// <summary>
/// 102剂量率报警 特殊操作Operate
/// </summary>
public class RadiomOpAlarmOperate102
{
    /// <summary>
    /// 都不报警
    /// </summary>
    public const int NONE = 0;

    /// <summary>
    /// 剂量率报警
    /// </summary>
    public const int RADIOM_ALARM = 1;

    /// <summary>
    /// 累计剂量率报警
    /// </summary>
    public const int TT_RADIOM_ALARM = 2;

    /// <summary>
    /// 都报警
    /// </summary>
    public const int BOTH = 3;
}

/// <summary>
/// 辐射仪操作类型
/// </summary>
public class RadiomOpType102
{
    /// <summary>
    /// 开关机
    /// </summary>
    public const int OpenClose = 1;

    /// <summary>
    /// 剂量率报警
    /// </summary>
    public const int RateAlarm = 2;

    /// <summary>
    /// 上电
    /// </summary>
    public const int Elec = 4;
}

/// <summary>
/// 操作辐射仪102
/// </summary>
public class RadiomeOp102Model
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}

#endregion

#region 102三防毒报
/// <summary>
/// 操作类型
/// </summary>
public class PoisAlarmOpType102
{
    /// <summary>
    /// 上电
    /// </summary>
    public const int Elec = 1;

    /// <summary>
    /// 开关机
    /// </summary>
    public const int OpenClose = 2;

    /// <summary>
    /// 报警
    /// </summary>
    public const int Alarm = 3;
}

/// <summary>
/// 操作三防装置毒报
/// </summary>
public class PoisAlarm102Model
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;

    public string GetTaskLog(int seatId)
    {
        switch (Type)
        {
            case PoisAlarmOpType102.Elec:
                return "三防毒报装置：" + (Operate == OperateDevice.OPEN ? "上电" : "离线");
            case PoisAlarmOpType102.OpenClose:
                switch (Operate)
                {
                    case 1:
                        return "三防毒报装置：开机";
                    case 2:
                        return "三防毒报装置：关机";
                    case 3:
                        return "三防毒报装置：自检";
                    default:
                        return "";
                }
            case PoisAlarmOpType102.Alarm:
                return "三防毒报装置：" + (Operate == OperateDevice.OPEN ? "开始报警" : "停止报警");
            default:
                return "";
        }
    }
}
#endregion

#region 102三防差压计
/// <summary>
/// 操作类型
/// </summary>
public class DiffPressureOpType102
{
    /// <summary>
    /// 上电
    /// </summary>
    public const int Elec = 1;

    /// <summary>
    /// 开关机
    /// </summary>
    public const int OpenClose = 2;

    /// <summary>
    /// 差压舱门
    /// </summary>
    public const int Gate = 3;
}

/// <summary>
/// 操作三防装置差压计
/// </summary>
public class DiffPressureOp102Model
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;

    public string GetTaskLog(int seatId)
    {
        switch (Type)
        {
            case DiffPressureOpType102.Elec:
                return "三防差压计：" + (Operate == OperateDevice.OPEN ? "上电" : "离线");
            case DiffPressureOpType102.OpenClose:
                return "三防差压计：" + (Operate == OperateDevice.OPEN ? "开机" : "关机");
            case DiffPressureOpType102.Gate:
                return "三防差压计：" + (Operate == OperateDevice.OPEN ? "差压舱门开启" : "差压舱门关闭");
            default:
                return "";
        }
    }
}
#endregion

public class PressModel
{
    public int Pressure;
}

#region 102三防辐射仪
/// <summary>
/// 操作类型
/// </summary>
public class Prre3RadiomOpType102
{
    /// <summary>
    /// 上电
    /// </summary>
    public const int Elec = 1;

    /// <summary>
    /// 开关机
    /// </summary>
    public const int OpenClose = 2;

    /// <summary>
    /// 报警
    /// </summary>
    public const int Alarm = 3;
}

/// <summary>
/// 操作三防装置辐射仪
/// </summary>
public class PreRadiomOp102Model
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;

    public string GetTaskLog(int seatId)
    {
        switch (Type)
        {
            case Prre3RadiomOpType102.Elec:
                return "三防辐射仪器：" + (Operate == OperateDevice.OPEN ? "上电" : "离线");
            case Prre3RadiomOpType102.OpenClose:
                return "三防辐射仪器：" + (Operate == OperateDevice.OPEN ? "开机" : "关机");
            case Prre3RadiomOpType102.Alarm:
                return "三防辐射仪器：" + (Operate == OperateDevice.OPEN ? "开始报警" : "停止报警");
            default:
                return "";
        }
    }
}
#endregion


#region 102车载质谱仪
/// <summary>
/// 操作类型
/// </summary>
public class CarMasssSpectOpType102
{
    /// <summary>
    /// 上电
    /// </summary>
    public const int Elec = 1;

    /// <summary>
    /// 氮气瓶总阀
    /// </summary>
    public const int NitrogenTap = 2;

    /// <summary>
    /// 电源
    /// </summary>
    public const int Power = 3;

    /// <summary>
    /// ZPY软件
    /// </summary>
    public const int ZPY = 4;

    /// <summary>
    /// 进样探杆密封盖
    /// </summary>
    public const int SampPoleCap = 5;

    /// <summary>
    /// 报警
    /// </summary>
    public const int Alarm = 6;
}

/// <summary>
/// 操作车载质谱仪
/// </summary>
public class CarMassSpectOp102Model
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;

    public string GetTaskLog(int seatId)
    {
        switch (Type)
        {
            case CarMasssSpectOpType102.Elec:
                return "车载质谱仪：" + (Operate == OperateDevice.OPEN ? "上电" : "离线");
            case CarMasssSpectOpType102.NitrogenTap:
                return "车载质谱仪：" + (Operate == OperateDevice.OPEN ? "氮气瓶总阀打开" : "氮气瓶总阀关闭");
            case CarMasssSpectOpType102.Power:
                return "车载质谱仪：" + (Operate == OperateDevice.OPEN ? "电源打开" : "电源关闭");
            case CarMasssSpectOpType102.ZPY:
                return "车载质谱仪：" + (Operate == OperateDevice.OPEN ? "ZPY打开" : "ZPY关闭");
            case CarMasssSpectOpType102.SampPoleCap:
                return "车载质谱仪：" + (Operate == OperateDevice.OPEN ? "进样探杆密封盖打开" : "进样探杆密封盖关闭");
            case CarMasssSpectOpType102.Alarm:
                return "车载质谱仪：" + (Operate == OperateDevice.OPEN ? "开始报警" : "报警结束");
            default:
                return "";
        }
    }
}
#endregion

#region 102红外遥测
/// <summary>
/// 操作类型
/// </summary>
public class InfaredTelemetryOpType102
{
    /// <summary>
    /// 上电
    /// </summary>
    public const int Elec = 1;

    /// <summary>
    /// 升
    /// </summary>
    public const int Rise = 2;

    /// <summary>
    /// 降
    /// </summary>
    public const int Drop = 3;


    /// <summary>
    /// 开关机
    /// </summary>
    public const int OpenClose = 4;

    /// <summary>
    /// 自检
    /// </summary>
    public const int Check = 5;

    /// <summary>
    /// 报警
    /// </summary>
    public const int Alarm = 6;
}

/// <summary>
/// 红外遥测
/// </summary>
public class InfaredTelemetryOp102Model
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}

/// <summary>
/// 红外遥测参数  102
/// </summary>
public class InfaredTelemetryParamModel
{
    /// <summary>
    /// 训练模式
    /// </summary>
    public int Tmode;

    /// <summary>
    /// 方向角
    /// </summary>
    public float Fxvalue;

    /// <summary>
    /// 俯仰角
    /// </summary>
    public float Fyvalue;

    public string GetTaskLog(int seatId)
    {
        return "训练模式： " + Tmode + "   \n方向角：" + Fxvalue + "    \n俯仰角：" + Fyvalue;
    }
}
/// <summary>
/// 检测到的毒种类
/// </summary>
public class InfaredTelemetryDrug
{
    public int Type;
}
#endregion
#region 102电源
/// <summary>
/// 操作类型
/// </summary>
public class PowerOpType102
{
    /// <summary>
    /// 输出
    /// </summary>
    public const int OutPut = 1;

    /// <summary>
    /// 开关机
    /// </summary>
    public const int OpenClose = 2;
}

/// <summary>
/// 电源
/// </summary>
public class PowerOp102Model
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}
#endregion

#region 102气象
/// <summary>
/// 操作类型
/// </summary>
public class MeteorOpType102
{
    /// <summary>
    /// 开关机
    /// </summary>
    public const int OpenClose = 1;

    /// <summary>
    /// 上电
    /// </summary>
    public const int Elec = 2;
}

/// <summary>
/// 气象设备
/// </summary>
public class MeteorOp102Model
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}
#endregion

/// <summary>
/// 设置辐射率阈值102
/// </summary>
public class SetRadiomThreShold102Model
{
    public float DoseThreshold;
}

/// <summary>
/// 设置累计辐射率阈值102
/// </summary>
public class SetTTRadiomThreShold102Model
{
    public float TotalDoseTreshold;
}


#region 384车载辐射仪
/// <summary>
/// 102剂量率报警 特殊操作Operate
/// </summary>
public class RadiomOpAlarmOperate384
{
    /// <summary>
    /// 都不报警
    /// </summary>
    public const int NONE = 0;

    /// <summary>
    /// 剂量率报警
    /// </summary>
    public const int RADIOM_ALARM = 1;

    /// <summary>
    /// 累计剂量率报警
    /// </summary>
    public const int TT_RADIOM_ALARM = 2;

    /// <summary>
    /// 都报警
    /// </summary>
    public const int BOTH = 3;
}

/// <summary>
/// 辐射仪操作类型
/// </summary>
public class RadiomOpType384
{
    /// <summary>
    /// 开关机
    /// </summary>
    public const int OpenClose = 1;

    /// <summary>
    /// 剂量率报警
    /// </summary>
    public const int RateAlarm = 2;

    /// <summary>
    /// 上电
    /// </summary>
    public const int Elec = 4;
}

/// <summary>
/// 操作辐射仪384
/// </summary>
public class RadiomeOp384Model
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}

#endregion

/// <summary>
/// 设置辐射计量率阈值384
/// </summary>
public class SetRadiomThreShold384Model
{
    public float DoseThreshold;
}

/// <summary>
/// 设置辐射仪累计剂量率阈值 384
/// </summary>
public class SetTotalRadiomThreHold384
{
    public float TotalDoseTreshold;
}

#region 操作毒剂报警器 384
/// <summary>
/// 毒剂报警器操作类型384
/// </summary>
public class PoisonAlarmOp384Type
{
    /// <summary>
    /// 上电
    /// </summary>
    public const int EleOn = 1;

    /// <summary>
    /// 空气进样
    /// </summary>
    public const int AirJinYang = 2;

    /// <summary>
    /// 地面进样
    /// </summary>
    public const int GroundJinYang = 3;

    /// <summary>
    /// 空气探头加热
    /// </summary>
    public const int AirProbHeat = 4;

    /// <summary>
    /// 地面探头加热
    /// </summary>
    public const int GroundProbHeat = 5;

    /// <summary>
    /// 故障
    /// </summary>
    public const int Error = 6;

    /// <summary>
    /// 状态
    /// </summary>
    public const int OpenStatus = 7;

    /// <summary>
    /// 报警
    /// </summary>
    public const int Alarm = 8;
}

/// <summary>
/// 操作毒剂报警器384
/// </summary>
public class PoisonAlarmOp384Model
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}

public class PoisonAlarmWorkType
{
    /// <summary>
    /// 空气检测
    /// </summary>
    public const int AIRE_CHECK = 1;

    /// <summary>
    /// 空气清洁
    /// </summary>
    public const int AIRE_CLEAN = 2;

    /// <summary>
    /// 地面检测
    /// </summary>
    public const int ROUND_CHECK = 3;

    /// <summary>
    /// 地面清洁
    /// </summary>
    public const int ROUND_CLEAN = 4;

    /// <summary>
    /// 除污
    /// </summary>
    public const int CLEAN = 5;
}

/// <summary>
/// 毒剂报警器选择工作模式384
/// </summary>
public class PoisonAlarmWorkType384Model
{
    /// <summary>
    /// 工作模式
    /// </summary>
    public int Type;
}

public class InfaredTelemetry102DrugModel
{
    /// <summary>
    /// 毒剂种类
    /// </summary>
    public int Type;
}
#endregion

#region 操作电源 384

/// <summary>
/// 电源操作类型
/// </summary>
public class PowerOp384Type
{
    /// <summary>
    /// 开关机
    /// </summary>
    public const int OpenClose = 1;

    /// <summary>
    /// 输出
    /// </summary>
    public const int OutPut = 2;
}

/// <summary>
/// 操作电源
/// </summary>
public class PowerOp384Model
{
    /// <summary>
    /// 操作 0关  1开
    /// </summary>
    public int Operate;

    /// <summary>
    /// 操作类型
    /// </summary>
    public int Type;
}

#endregion
