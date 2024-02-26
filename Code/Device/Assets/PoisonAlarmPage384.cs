using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoisonAlarmPage384 : MonoBehaviour
{
    public Toggle air;

    public Toggle ground;

    public Toggle kaiguan;

    public Toggle alarm;

    public Toggle groundHot;

    public Toggle airHot;

    public Toggle elec;

    public Toggle preHot;

    public ButtonBase close;

    /// <summary>
    /// 工作模式
    /// </summary>
    public Dropdown workType;

    public ButtonBase setWorkType;

    private void Awake()
    {
        close.RegistClick(OnClickClose);
        air.onValueChanged.AddListener(OnAirValueChanged);
        ground.onValueChanged.AddListener(OnGroundValueChanged);
        alarm.onValueChanged.AddListener(OnAlarmValueChanged);
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        groundHot.onValueChanged.AddListener(OnGroundHotValueChanged);
        airHot.onValueChanged.AddListener(OnAirHotValueChanged);
        elec.onValueChanged.AddListener(OnElecValueChanged);
        preHot.onValueChanged.AddListener(OnPreHotValueChanged);
        setWorkType.RegistClick(OnClickSetWorkType);
    }

    private void OnClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 空气进样
    /// </summary>
    private void OnAirValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp384Type.AirJinYang, value ? 1 : 0);
    }

    /// <summary>
    /// 地面进样
    /// </summary>
    private void OnGroundValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp384Type.GroundJinYang, value ? 1 : 0);
    }

    /// <summary>
    /// 开关
    /// </summary>
    private void OnKaiGuanValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp384Type.OpenStatus, value ? 2 : 0);
    }

    /// <summary>
    /// 报警
    /// </summary>
    private void OnAlarmValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp384Type.Alarm, value ? 1 : 0);
    }

    /// <summary>
    /// 地面加热
    /// </summary>
    private void OnGroundHotValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp384Type.GroundProbHeat, value ? 1 : 0);
    }

    /// <summary>
    /// 地面加热
    /// </summary>
    private void OnAirHotValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp384Type.AirProbHeat, value ? 1 : 0);
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOp384Type.EleOn, value ? 1 : 0);
    }

    /// <summary>
    /// 预热
    /// </summary>
    private void OnPreHotValueChanged(bool value)
    {
        if (value)
        {
            SendOperateMsg(PoisonAlarmOp384Type.OpenStatus, 1);
        }
    }

    /// <summary>
    /// 下发操作消息
    /// </summary>
    private void SendOperateMsg(int opType, int operate)
    {
        PoisonAlarmOp384Model opModel = new PoisonAlarmOp384Model()
        {
            Operate = operate,
            Type = opType,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.POISON_ALARM_OP_384);
    }

    private void OnClickSetWorkType(GameObject obj)
    {
        PoisonAlarmWorkType384Model model = new PoisonAlarmWorkType384Model()
        {
            Type = workType.value + 1,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(model), NetProtocolCode.POISON_ALARM_WORK_TYPE_384);
    }
}
