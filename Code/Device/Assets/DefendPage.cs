
using UnityEngine;
using UnityEngine.UI;

public class DefendPage : MonoBehaviour
{
    /// <summary>
    /// 毒报上电
    /// </summary>
    public Toggle DrugElec;

    /// <summary>
    /// 毒报开关机
    /// </summary>
    public Toggle DrugOpenClose;

    /// <summary>
    /// 毒报自检
    /// </summary>
    public Toggle DrugCheck;

    /// <summary>
    /// 毒报报警
    /// </summary>
    public Toggle DrugAlarm;


    /// <summary>
    /// 差压计上电
    /// </summary>
    public Toggle PressElec;

    /// <summary>
    /// 差压计开关机
    /// </summary>
    public Toggle PressOpenClose;

    /// <summary>
    /// 差压计舱门
    /// </summary>
    public Toggle PressGate;

    /// <summary>
    /// 压力值
    /// </summary>
    public InputField pressInput;

    public ButtonBase setPressBtn;


    /// <summary>
    /// 辐射仪上电
    /// </summary>
    public Toggle RadiomElec;

    /// <summary>
    /// 辐射仪开关机
    /// </summary>
    public Toggle RadiomOpenClose;

    /// <summary>
    /// 辐射仪报警
    /// </summary>
    public Toggle RadiomAlarm;

    public ButtonBase close;

    private void Awake()
    {
        close.RegistClick(OnClickClose);
        DrugElec.onValueChanged.AddListener(OnDrugElecValueChanged);
        DrugOpenClose.onValueChanged.AddListener(OnDrugOpenCloseValueChanged);
        DrugCheck.onValueChanged.AddListener(OnDrugCheckValueChanged);
        DrugAlarm.onValueChanged.AddListener(OnDrugAlarmValueChanged);
        PressElec.onValueChanged.AddListener(OnPressElecValueChanged);
        PressOpenClose.onValueChanged.AddListener(OnPressOpenCloseValueChanged);
        PressGate.onValueChanged.AddListener(OnPressGateeValueChanged);
        setPressBtn.RegistClick(OnClickSetPressBtn);
        RadiomElec.onValueChanged.AddListener(OnRadiomElecValueChanged);
        RadiomOpenClose.onValueChanged.AddListener(OnRadiomOpenCloseValueChanged);
        RadiomAlarm.onValueChanged.AddListener(OnRadiomAlarmValueChanged);
    }
    private void OnClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    private void OnDrugElecValueChanged(bool value)
    {
        SendDrugOperateMsg(PoisAlarmOpType102.Elec, value ? 1 : 0);
    }

    private void OnDrugOpenCloseValueChanged(bool value)
    {
        SendDrugOperateMsg(PoisAlarmOpType102.OpenClose, value ? 1 : 2);
    }

    private void OnDrugCheckValueChanged(bool value)
    {
        if (value)
        {
            SendDrugOperateMsg(PoisAlarmOpType102.OpenClose, 3);
        }
    }

    private void OnDrugAlarmValueChanged(bool value)
    {
        SendDrugOperateMsg(PoisAlarmOpType102.Alarm, value ? 1 : 0);
    }

    /// <summary>
    /// 发送毒报操作消息
    /// </summary>
    private void SendDrugOperateMsg(int opType, int operate)
    {
        PoisAlarm102Model model = new PoisAlarm102Model()
        {
            Type = opType,
            Operate = operate
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(model), NetProtocolCode.POIS_ALARM_102);
    }



    private void OnPressElecValueChanged(bool value)
    {
        SendPressOperateMsg(DiffPressureOpType102.Elec, value ? 1 : 0);
    }

    private void OnPressOpenCloseValueChanged(bool value)
    {
        SendPressOperateMsg(DiffPressureOpType102.OpenClose, value ? 1 : 0);
    }

    private void OnPressGateeValueChanged(bool value)
    {
        SendPressOperateMsg(DiffPressureOpType102.Gate, value ? 1 : 0);
    }

    /// <summary>
    /// 发送差压计操作消息
    /// </summary>
    private void SendPressOperateMsg(int opType, int operate)
    {
        DiffPressureOp102Model model = new DiffPressureOp102Model()
        {
            Type = opType,
            Operate = operate
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(model), NetProtocolCode.DIFF_PRESSURE_102);
    }

    private void OnClickSetPressBtn(GameObject obj)
    {
        PressModel model = new PressModel()
        {
            Pressure = pressInput.text.ToInt(),
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(model), NetProtocolCode.PRESS_102);
    }

    private void OnRadiomElecValueChanged(bool value)
    {
        SendRadiomOperateMsg(Prre3RadiomOpType102.Elec, value ? 1 : 0);
    }

    private void OnRadiomOpenCloseValueChanged(bool value)
    {
        SendRadiomOperateMsg(Prre3RadiomOpType102.OpenClose, value ? 1 : 0);
    }

    private void OnRadiomAlarmValueChanged(bool value)
    {
        SendRadiomOperateMsg(Prre3RadiomOpType102.Alarm, value ? 1 : 0);
    }

    /// <summary>
    /// 发送辐射仪操作消息
    /// </summary>
    private void SendRadiomOperateMsg(int opType, int operate)
    {
        PreRadiomOp102Model model = new PreRadiomOp102Model()
        {
            Type = opType,
            Operate = operate
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(model), NetProtocolCode.PREVENT_DEVICE_RADIOM_102);
    }
}
