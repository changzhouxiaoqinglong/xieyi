using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadiomPage102 : MonoBehaviour
{
    public Toggle kaiguan;

    public Toggle alarm;

    public Toggle totalAlarm;
    public Toggle elec;

    public ButtonBase close;

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

    private void Awake()
    {
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        alarm.onValueChanged.AddListener(OnAlarmValueChanged);
        totalAlarm.onValueChanged.AddListener(OnTotalAlarmValueChanged);
        elec.onValueChanged.AddListener(OnElecValueChanged);
        setBtn.RegistClick(OnClickSetBtn);
        close.RegistClick(CloseThis);
    }

    /// <summary>
    /// 开关
    /// </summary>
    private void OnKaiGuanValueChanged(bool value)
    {
        SendOperateMsg(RadiomOpType102.OpenClose, value ? 1 : 0);
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
            SendOperateMsg(RadiomOpType102.RateAlarm, 3);
        }
        else if (alarm)
        {
            SendOperateMsg(RadiomOpType102.RateAlarm, 1);
        }
        else if (totalAlarm)
        {
            SendOperateMsg(RadiomOpType102.RateAlarm, 2);
        }
        else
        {
            SendOperateMsg(RadiomOpType102.RateAlarm, 0);
        }
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        SendOperateMsg(RadiomOpType.Elec, value ? 1 : 0);
    }

    /// <summary>
    /// 发送操作消息
    /// </summary>
    private void SendOperateMsg(int opType, int operate)
    {
        //操作数据
        RadiomeOp102Model opModel = new RadiomeOp102Model()
        {
            Operate = operate,
            Type = opType,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.CAR_RADIOM_OP_102);
    }

    private void OnClickSetBtn(GameObject obj)
    {
        SetRadiomThreShold102Model set = new SetRadiomThreShold102Model()
        {
            DoseThreshold = dose.text.ToFloat(),
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(set), NetProtocolCode.SET_RADIOM_RATE_THRESHOLD_102);

        SetTTRadiomThreShold102Model setTotal = new SetTTRadiomThreShold102Model()
        {
            TotalDoseTreshold = totalDose.text.ToFloat(),
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(setTotal), NetProtocolCode.SET_TT_RADIOM_RATE_THRESHOLD_102);
    }

    private void CloseThis(GameObject @object)
    {
        gameObject.SetActive(false);
    }
}
