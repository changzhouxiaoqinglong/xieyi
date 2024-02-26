using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{

    /// <summary>
    /// 关闭
    /// </summary>
    public ButtonBase closeBtn;

    /// <summary>
    /// 毒剂报警器
    /// </summary>
    public ButtonBase PoisonAlarm;

    public GameObject poisonPage;

    /// <summary>
    /// 辐射仪
    /// </summary>
    public ButtonBase RadiomeBtn;

    public GameObject RadiomePage;

    /// <summary>
    /// 电源
    /// </summary>
    public ButtonBase powerBtn;

    public GameObject powerPage;

    /// <summary>
    /// 北斗
    /// </summary>
    public ButtonBase beiDouBtn;

    public GameObject beiDouPage;


    /// <summary>
    /// 气象
    /// </summary>
    public ButtonBase meteorBtn;

    public GameObject meteroPage;

    /// <summary>
    /// 车载侦毒器
    /// </summary>
    public ButtonBase carDetect;

    public GameObject carDetectPage;
    private void Awake()
    {
        PoisonAlarm.RegistClick(OnClickPoisonAlarm);
        RadiomeBtn.RegistClick(OnClickRadiomeBtn);
        powerBtn.RegistClick(OnClickPower);
        beiDouBtn.RegistClick(OnClickBeiDou);
        meteorBtn.RegistClick(OnClickMetero);
        carDetect.RegistClick(OnClickCarDetect);
        closeBtn.RegistClick(ClickClose);
    }

    private void OnClickPoisonAlarm(GameObject obj)
    {
        poisonPage.SetActive(true);
    }

    private void OnClickRadiomeBtn(GameObject obj)
    {
        RadiomePage.SetActive(true);
    }

    private void OnClickPower(GameObject obj)
    {
        powerPage.SetActive(true);
    }

    private void OnClickBeiDou(GameObject obj)
    {
        beiDouPage.SetActive(true);
    }

    private void OnClickMetero(GameObject obj)
    {
        meteroPage.SetActive(true);
    }

    private void OnClickCarDetect(GameObject obj)
    {
        carDetectPage.SetActive(true);
    }

    private void ClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }
}
