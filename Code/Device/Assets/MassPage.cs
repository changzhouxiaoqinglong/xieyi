
using UnityEngine;
using UnityEngine.UI;

public class MassPage : MonoBehaviour
{
    public Toggle elec;

    public Toggle danqi;

    public Toggle power;

    public Toggle zpy;

    public Toggle jinyang;

    public Toggle alarm;

    public ButtonBase close;

    private void Awake()
    {
        close.RegistClick(OnClickClose);
        elec.onValueChanged.AddListener(OnElecValueChanged);
        danqi.onValueChanged.AddListener(OnDanQiValueChanged);
        power.onValueChanged.AddListener(OnPowerValueChanged);
        zpy.onValueChanged.AddListener(OnZPYValueChanged);
        jinyang.onValueChanged.AddListener(OnJinYangValueChanged);
        alarm.onValueChanged.AddListener(OnAlarmValueChanged);
    }

    private void OnClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        SendOperateMsg(CarMasssSpectOpType102.Elec, value ? 1 : 0);
    }

    /// <summary>
    /// 氮气阀
    /// </summary>
    private void OnDanQiValueChanged(bool value)
    {
        SendOperateMsg(CarMasssSpectOpType102.NitrogenTap, value ? 1 : 0);
    }

    /// <summary>
    /// 电源
    /// </summary>
    private void OnPowerValueChanged(bool value)
    {
        SendOperateMsg(CarMasssSpectOpType102.Power, value ? 1 : 0);
    }

    /// <summary>
    /// zpy
    /// </summary>
    private void OnZPYValueChanged(bool value)
    {
        SendOperateMsg(CarMasssSpectOpType102.ZPY, value ? 1 : 0);
    }

    /// <summary>
    /// 进样探杆
    /// </summary>
    private void OnJinYangValueChanged(bool value)
    {
        SendOperateMsg(CarMasssSpectOpType102.SampPoleCap, value ? 1 : 0);
    }

    /// <summary>
    /// 报警
    /// </summary>
    private void OnAlarmValueChanged(bool value)
    {
        SendOperateMsg(CarMasssSpectOpType102.Alarm, value ? 1 : 0);
    }

    /// <summary>
    /// 质谱仪操作消息
    /// </summary>
    private void SendOperateMsg(int opType, int operate)
    {
        CarMassSpectOp102Model opModel = new CarMassSpectOp102Model()
        {
            Operate = operate,
            Type = opType,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.CAR_MASS_SPECT_102);
    }
}
