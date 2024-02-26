
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 操作类型
/// </summary>
public class PowerOpType
{
    public const int kaiguan = 1;

    public const int elec = 2;

    public const int output = 3;
}


public class PowerPage : MonoBehaviour
{
    public Toggle kaiguan;

    public Toggle elec;

    public Toggle outPut;

    public ButtonBase close;

    private void Awake()
    {
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        elec.onValueChanged.AddListener(OnElecValueChanged);
        outPut.onValueChanged.AddListener(OnOutPutValueChanged);
        close.RegistClick(OnClickClose);
    }

    private void OnClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 开关
    /// </summary>
    private void OnKaiGuanValueChanged(bool value)
    {
        PowerOpModel opModel = new PowerOpModel()
        {
            Operate = value ? 1 : 0,
            Type = PowerOpType.kaiguan,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.POWER_OP);
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        PowerOpModel opModel = new PowerOpModel()
        {
            Operate = value ? 1 : 0,
            Type = PowerOpType.elec,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.POWER_OP);
    }


    /// <summary>
    /// 输出
    /// </summary>
    private void OnOutPutValueChanged(bool value)
    {
        PowerOpModel opModel = new PowerOpModel()
        {
            Operate = value ? 1 : 0,
            Type = PowerOpType.output,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.POWER_OP);
    }
}
