using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadiomPage384 : MonoBehaviour
{
    public Toggle kaiguan;

    public Toggle alarm;

    public Toggle totalAlarm;
    public Toggle elec;

    public ButtonBase close;

    public Toggle check;

    /// <summary>
    /// 剂量率阈值
    /// </summary>
    public InputField dose;

    /// <summary>
    /// 累计剂量率阈值
    /// </summary>
    public InputField totalDose;

    /// <summary>
    /// 设置按钮
    /// </summary>
    public ButtonBase setBtn;

    /// <summary>
    /// 当前剂量率显示
    /// </summary>
    public Text curRateText;

    private void Awake()
    {
        close.RegistClick(OnClickClose);
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        alarm.onValueChanged.AddListener(OnAlarmValueChanged);
        totalAlarm.onValueChanged.AddListener(OnTotalAlarmValueChanged);
        elec.onValueChanged.AddListener(OnElecValueChanged);
        setBtn.RegistClick(OnClickSetBtn);
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
        SendOperateMsg(RadiomOpType384.OpenClose, value ? 1 : 0);
    }

    /// <summary>
    /// 剂量率报警
    /// </summary>
    private void OnAlarmValueChanged(bool value)
    {
        OnChangeAlarm();
    }

    /// <summary>
    /// 累计剂量率报警
    /// </summary>
    private void OnTotalAlarmValueChanged(bool value)
    {
        OnChangeAlarm();
    }

    /// <summary>
    /// 报警变化
    /// </summary>
    private void OnChangeAlarm()
    {
        bool alarm = this.alarm.isOn;
        bool totalAlarm = this.totalAlarm.isOn;
        if (alarm && totalAlarm)
        {
            SendOperateMsg(RadiomOpType384.RateAlarm, 3);
        }
        else if (alarm)
        {
            SendOperateMsg(RadiomOpType384.RateAlarm, 1);
        }
        else if (totalAlarm)
        {
            SendOperateMsg(RadiomOpType384.RateAlarm, 2);
        }
        else
        {
            SendOperateMsg(RadiomOpType384.RateAlarm, 0);
        }
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        SendOperateMsg(RadiomOpType384.Elec, value ? 1 : 0);
    }

    /// <summary>
    /// 下发操作消息
    /// </summary>
    private void SendOperateMsg(int opType, int operate)
    {
        RadiomeOp384Model opModel = new RadiomeOp384Model()
        {
            Operate = operate,
            Type = opType,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.RADIOME_OP_384);
    }

    private void OnClickSetBtn(GameObject obj)
    {
        SetRadiomThreShold384Model set = new SetRadiomThreShold384Model()
        {
            DoseThreshold = dose.text.ToFloat(),
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(set), NetProtocolCode.SET_RADIOM_RATE_THRESHOLD_384);

        SetTotalRadiomThreHold384 setTotal = new SetTotalRadiomThreHold384()
        {
            TotalDoseTreshold = totalDose.text.ToFloat(),
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(setTotal), NetProtocolCode.SET_TT_RADIOM_RATE_THRESHOLD_384);
    }

    /// <summary>
    /// 接收辐射剂量率
    /// </summary>
    private void OnRevRadiomRate(IEventParam param)
    {
        if (param is TcpReceiveEvParam tcpPram)
        {
            SetDoseRateModel model = JsonTool.ToObject<SetDoseRateModel>(tcpPram.netData.Msg);
            curRateText.text = "当前辐射剂量率为：" + model.DoseRate + "  uGy/h";
        }
    }
}
