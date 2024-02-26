
using UnityEngine;
using UnityEngine.UI;

public class PowerPage384 : MonoBehaviour
{
    public Toggle output;

    public Toggle kaiguan;

    public ButtonBase close;

    private void OnClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        close.RegistClick(OnClickClose);
        output.onValueChanged.AddListener(OnOutPutValueChanged);
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
    }

    private void OnOutPutValueChanged(bool value)
    {
        SendOperateMsg(PowerOp384Type.OutPut, value ? 1 : 0); ;
    }

    private void OnKaiGuanValueChanged(bool value)
    {
        SendOperateMsg(PowerOp384Type.OpenClose, value ? 1 : 0); ;
    }

    /// <summary>
    /// 下发操作消息
    /// </summary>
    private void SendOperateMsg(int opType, int operate)
    {
        PowerOp384Model opModel = new PowerOp384Model()
        {
            Operate = operate,
            Type = opType,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.POWER_OP_384);
    }
}
