
using UnityEngine;
using UnityEngine.UI;

public class PowerPage102 : MonoBehaviour
{
    public Toggle output;

    public ButtonBase close;

    private void Awake()
    {
        close.RegistClick(OnClickClose);
        output.onValueChanged.AddListener(OnOutPutValueChanged);
    }

    private void OnClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    private void OnOutPutValueChanged(bool value)
    {
        SendOperateMsg(PowerOpType102.OutPut, value ? 1 : 0); ;
    }

    /// <summary>
    /// 下发操作消息
    /// </summary>
    private void SendOperateMsg(int opType, int operate)
    {
        PowerOp102Model opModel = new PowerOp102Model()
        {
            Operate = operate,
            Type = opType,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.POWER_102);
    }
}
