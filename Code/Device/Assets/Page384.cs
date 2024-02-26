
using UnityEngine;

public class Page384 : MonoBehaviour
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

    private void Awake()
    {
        PoisonAlarm.RegistClick(OnClickPoisonAlarm);
        RadiomeBtn.RegistClick(OnClickRadiomeBtn);
        powerBtn.RegistClick(OnClickPower);
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

    private void ClickClose(GameObject obj)
    {
        gameObject.SetActive(false);
    }
}
