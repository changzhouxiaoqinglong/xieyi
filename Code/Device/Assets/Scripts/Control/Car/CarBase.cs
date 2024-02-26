
using UnityEngine;

/// <summary>
/// 车辆接口
/// </summary>
public interface ICar
{

}

/// <summary>
/// 车辆基类
/// </summary>
public class CarBase : UnityMono, ICar
{
    /// <summary>
    /// 当前车辆对应的数据
    /// </summary>
    public ExCarData CurCarData { get; set; }


}
