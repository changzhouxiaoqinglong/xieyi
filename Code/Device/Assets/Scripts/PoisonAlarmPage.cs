
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 毒剂报警器操作类型
/// </summary>
public class PoisonAlarmOpType
{
    public const int jinqi = 1;

    public const int kaiguanji = 2;

    public const int jinyang = 3;

    public const int alarm = 4;

    /// <summary>
    /// 上电
    /// </summary>
    public const int EleOn = 5;

    /// <summary>
    /// 自检
    /// </summary>
    public const int Check = 6;
}

public class PoisonAlarmPage : MonoBehaviour
{
    /// <summary>
    /// 进气帽
    /// </summary>
    public Toggle jinqimao;

    public Toggle kaiguan;


    public Toggle jinyang;

    public Toggle alarm;

    public ButtonBase close;

    public Toggle check;

    public Toggle Elec;

    public Toggle jinyangStatus;
    private void Awake()
    {
        close.RegistClick(OnClickClose);
        check.onValueChanged.AddListener(OnClickCheck);
        jinqimao.onValueChanged.AddListener(OnJinQiValueChanged);
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        jinyang.onValueChanged.AddListener(OnJinYangValueChanged);
        alarm.onValueChanged.AddListener(OnAlarmValueChanged);
        Elec.onValueChanged.AddListener(OnElecValueChanged);
        jinyangStatus.onValueChanged.AddListener(OnInStatusValueChanged);
    }

    private void OnClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    private void OnClickCheck(bool value)
    {
        SendOperateMsg(PoisonAlarmOpType.Check, value ? 1 : 0);
    }

    /// <summary>
    /// 进气帽
    /// </summary>
    private void OnJinQiValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOpType.jinqi, value ? 1 : 0);
    }

    /// <summary>
    /// 开关
    /// </summary>
    private void OnKaiGuanValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOpType.kaiguanji, value ? 1 : 0);
    }

    /// <summary>
    /// 进样
    /// </summary>
    private void OnJinYangValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOpType.jinyang, value ? 1 : 0);
    }

    /// <summary>
    /// 报警
    /// </summary>
    private void OnAlarmValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOpType.alarm, value ? 1 : 0);
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        SendOperateMsg(PoisonAlarmOpType.EleOn, value ? 1 : 0);
    }

    /// <summary>
    /// 进样情况
    /// </summary>
    private void OnInStatusValueChanged(bool value)
    {
        PoisonInStatusModel model = new PoisonInStatusModel()
        {
            Status = value ? 1 : 0,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(model), NetProtocolCode.POISON_IN_STATUS);
    }

    /// <summary>
    /// 下发操作消息
    /// </summary>    
    private void SendOperateMsg(int opType, int operate)
    {
        PoisonAlarmOpModel opModel = new PoisonAlarmOpModel()
        {
            Operate = operate,
            Type = opType,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.POISON_ALARM_OP);
    }
}
