using System.Collections.Generic;

/// <summary>
/// 下发的任务环境信息
/// </summary>
public class TaskEnvVarData
{
    /// <summary>
    /// 任务编号
    /// </summary>
    public int TaskId;

    /// <summary>
    /// 场景
    /// </summary>
    public int Scene;

    /// <summary>
    /// 风向
    /// </summary>
    public int WindDir;

    /// <summary>
    /// 风速
    /// </summary>
    public int WindSp;

    /// <summary>
    /// 温度
    /// </summary>
    public int Temperate;

    /// <summary>
    /// 湿度
    /// </summary>
    public int Humidity;

    /// <summary>
    /// 车型编号
    /// </summary>
    public int CarId;

    /// <summary>
    /// 车辆位置
    /// </summary>
    public string CardPos;

    /// <summary>
    /// 有害元素信息
    /// </summary>
    public List<HarmData> HarmDatas = new List<HarmData>();

    /// <summary>
    /// 获得描述
    /// </summary>
    public string GetDesc()
    {
        //任务数据
        ExTaskData exTaskData = TaskExDataMgr.GetInstance().GetDataById(TaskId);
        //场景数据
        ExSceneData exSceneData = SceneExDataMgr.GetInstance().GetDataById(Scene);
        return "收到任务：".Append(exTaskData.Desc).Append("\n")
            .Append("场景： ").Append(exSceneData.Desc).Append("\n")
            .Append("风向：").Append(WindDir).Append("\n")
            .Append("风速：").Append(WindSp).Append("\n")
            .Append("温度：").Append(Temperate).Append("\n")
            .Append("湿度：").Append(Humidity).Append("\n").ToString();
    }
}

/// <summary>
/// 有害元素
/// </summary>
public class HarmData
{
    public enum HarmTypeEnum
    {
        /// <summary>
        /// 毒剂
        /// </summary>
        Drug = 1,

        /// <summary>
        /// 辐射
        /// </summary>
        Radiate,
    }

    /// <summary>
    /// 类型
    /// </summary>
    public int HarmType;

    /// <summary>
    /// 具体内容
    /// </summary>
    public string Content;
}


/// <summary>
/// 下发毒数据
/// </summary>
public class DrugVarData
{
    public int Id;

    public int Type;

    public string Pos;

    public int Range;

    public int Dentity;
}

/// <summary>
/// 下发辐射数据
/// </summary>
public class RadiatVarData
{
    public int Id;

    public string Pos;

    public int Range;

    public int DoseRate;

    public int TotalDose;
}

