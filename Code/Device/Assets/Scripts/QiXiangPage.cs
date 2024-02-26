using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 操作类型
/// </summary>
public class QiXiangOpType
{
    public const int kaiguan = 1;
    public const int elec = 2;
}

public class QiXiangPage : MonoBehaviour
{
    public Toggle kaiguan;

    public Toggle elec;

    public ButtonBase close;



    private void Awake()
    {
        kaiguan.onValueChanged.AddListener(OnKaiGuanValueChanged);
        elec.onValueChanged.AddListener(OnElecValueChanged);
        close.RegistClick(OnClickClose);
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
        MeteorOpModel opModel = new MeteorOpModel()
        {
            Operate = value ? 1 : 0,
            Type = BeiDouOpType.kaiguan,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.METEOR_OP);
    }

    /// <summary>
    /// 上电
    /// </summary>
    private void OnElecValueChanged(bool value)
    {
        MeteorOpModel opModel = new MeteorOpModel()
        {
            Operate = value ? 1 : 0,
            Type = BeiDouOpType.elec,
        };
        NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(opModel), NetProtocolCode.METEOR_OP);
    }
}
