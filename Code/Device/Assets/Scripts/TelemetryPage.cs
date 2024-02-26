
using UnityEngine;
using UnityEngine.UI;

public class TelemetryPage : MonoBehaviour
{
    public Toggle kaiguan;

    public Toggle elec;

    public Toggle alarm;


    public ButtonBase close;

    public Toggle check;

    public Toggle startUp;
    public Toggle startDown;
    /// <summary>
    /// x方向角
    /// </summary>
    public InputField fxValue;

    /// <summary>
    /// y方向角
    /// </summary>
    public InputField fyValue;

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
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        elec.onValueChanged.AddListener(OnElecValueChanged);
        alarm.onValueChanged.AddListener(OnAlarmValueChanged);
        check.onValueChanged.AddListener(OnCheckValueChanged);
        close.RegistClick(OnClickClose);
        startUp.onValueChanged.AddListener(OnStartUpValueChanged);
        startDown.onValueChanged.AddListener(OnStartDownValueChanged);
        setBtn.RegistClick(OnClickSetBtn);
        NetManager.GetInstance().AddNetMsgEventListener(ServerType.LocalServer, NetProtocolCode.SEND_RADIOM_RATE, OnRevRadiomRate);
    }

    private void OnClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }


    /// <summary>
    /// 开始上升
    /// </summary>
    private void OnStartUpValueChanged(bool value)
    {
        SendOperateMsg(InfaredTelemetryOpType102.Rise, value ? 1 : 0);
    }

    /// <summary>
    /// 开始下降
    /// </summary>
    private void OnStartDownValueChanged(bool value)
    {
        SendOperateMsg(InfaredTelemetryOpType102.Drop, value ? 1 : 0);
    }

    private void OnKaiGuanValueChanged(bool value)
    {
        SendOperateMsg(InfaredTelemetryOpType102.OpenClose, value ? 1 : 0);
    }

    private void OnElecValueChanged(bool value)
    {
        SendOperateMsg(InfaredTelemetryOpType102.Elec, value ? 1 : 0);
    }

    private void OnCheckValueChanged(bool value)
    {
        SendOperateMsg(InfaredTelemetryOpType102.Check, value ? 1 : 0);
    }

    private void OnAlarmValueChanged(bool value)
    {
        SendOperateMsg(InfaredTelemetryOpType102.Alarm, value ? 1 : 0);
    }

    /// <summary>
    /// 下发操作消息
    /// </summary>
    private void SendOperateMsg(int opType, int operate)
    {
        InfaredTelemetryOp102Model opModel = new InfaredTelemetryOp102Model()
        {
            Operate = operate,
            Type = opType,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.INFARED_TELEMETRY_102);
    }

    private void OnClickSetBtn(GameObject obj)
    {
        InfaredTelemetryParamModel model = new InfaredTelemetryParamModel()
        {
            Fxvalue = fxValue.text.ToFloat(),
            Fyvalue = fyValue.text.ToFloat(),
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(model), NetProtocolCode.INFARED_TELEMETRY_PARAM_102);
    }

    /// <summary>
    /// 接收辐射剂量率
    /// </summary>
    private void OnRevRadiomRate(IEventParam param)
    {
        if (param is TcpReceiveEvParam tcpPram)
        {
            InfaredTelemetryOp102Model model = JsonTool.ToObject<InfaredTelemetryOp102Model>(tcpPram.netData.Msg);
            curRateText.text = "当前类型：" + model.Type + "  uGy/h";
        }
    }

    private void OnDestroy()
    {
        NetManager.GetInstance().RemoveNetMsgEventListener(ServerType.LocalServer, NetProtocolCode.INFARED_TELEMETRY_102, OnRevRadiomRate);
    }
}
