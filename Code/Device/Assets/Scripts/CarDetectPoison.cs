using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 操作类型
/// </summary>
public class CarDetectPoisonType
{
    public const int kaiguan = 2;
    public const int elec = 3;
    /// <summary>
    /// 加热泵
    /// </summary>
    public const int HeatPump = 1;
}

public class CarDetectPoison : MonoBehaviour
{
    public Toggle kaiguan;

    public Toggle elec;

    public Toggle heatPump;

    public ButtonBase close;



    private void Awake()
    {
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        elec.onValueChanged.AddListener(OnElecValueChanged);
        heatPump.onValueChanged.AddListener(OnHeatPumpValueChanged);
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
        CarDetectPoisonOpModel opModel = new CarDetectPoisonOpModel()
        {
            Operate = value ? 1 : 0,
            Type = CarDetectPoisonType.kaiguan,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.OP_CAR_DETECT_POISON);
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        CarDetectPoisonOpModel opModel = new CarDetectPoisonOpModel()
        {
            Operate = value ? 1 : 0,
            Type = CarDetectPoisonType.elec,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.OP_CAR_DETECT_POISON);
    }

    /// <summary>
    /// 加热泵
    /// </summary>
    private void OnHeatPumpValueChanged(bool value)
    {
        CarDetectPoisonOpModel opModel = new CarDetectPoisonOpModel()
        {
            Operate = value ? 1 : 0,
            Type = CarDetectPoisonType.HeatPump,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.OP_CAR_DETECT_POISON);
    }
}
