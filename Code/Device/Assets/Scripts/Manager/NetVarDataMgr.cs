
using UnityEngine;

/// <summary>
/// 网络获取的动态数据 
/// </summary>
public class NetVarData
{
    /// <summary>
    /// 用户数据
    /// </summary>
    public UserInfo _UserInfo { get; set; }

    /// <summary>
    /// 任务环境数据
    /// </summary>
    public TaskEnvVarData _TaskEnvVarData { get; set; }
}

/// <summary>
/// 网络获取的动态数据管理
/// </summary>
public class NetVarDataMgr : SingleTonBase<NetVarDataMgr>
{
    /// <summary>
    /// 网络数据
    /// </summary>
    public NetVarData _NetVarData { get; set; } = new NetVarData();
}
