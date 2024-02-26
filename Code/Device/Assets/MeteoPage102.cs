using UnityEngine;
using UnityEngine.UI;

public class MeteoPage102 : MonoBehaviour
{
    public ButtonBase close;

    public Toggle kaiguan;

    public Toggle elec;

    private void Awake()
    {
        close.RegistClick(OnClickClose);
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        elec.onValueChanged.AddListener(OnElecValueChanged);
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
        SendOperateMsg(MeteorOpType102.OpenClose, value ? 1 : 0);
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        SendOperateMsg(MeteorOpType102.Elec, value ? 1 : 0);
    }

    /// <summary>
    /// 下发操作消息
    /// </summary>
    private void SendOperateMsg(int opType, int operate)
    {
        MeteorOp102Model opModel = new MeteorOp102Model()
        {
            Operate = operate,
            Type = opType,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.METEOR_102);
    }
}
