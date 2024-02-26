
using UnityEngine;

public class Page102 : MonoBehaviour
{
    public ButtonBase closeBtn;

    /// <summary>
    /// 车载辐射仪按钮
    /// </summary>
    public ButtonBase RadiomBtn;

    public GameObject radiomPage;

    /// <summary>
    /// 三防按钮
    /// </summary>
    public ButtonBase defendBtn;

    public GameObject defendPage;

    /// <summary>
    /// 质谱仪按钮
    /// </summary>
    public ButtonBase MassBtn;

    public GameObject massPage;

    /// <summary>
    /// 红外遥测
    /// </summary>
    public ButtonBase telemerty;
    public GameObject telemertyPage;

    /// <summary>
    /// 电源
    /// </summary>
    public ButtonBase power;
    public GameObject powerPage;

    /// <summary>
    /// 气象
    /// </summary>
    public ButtonBase meteo;
    public GameObject meteoPage;

    private void Awake()
    {
        RadiomBtn.RegistClick(OnClickRadiom);
        closeBtn.RegistClick(CloseThis);
        defendBtn.RegistClick(OnClickDefend);
        MassBtn.RegistClick(OnClickMass);
        telemerty.RegistClick(OnClickTelemetry);
        power.RegistClick(OnClickPower);
        meteo.RegistClick(OnClickMeteo);
    }

    private void OnClickRadiom(GameObject obj)
    {
        radiomPage.SetActive(true);
    }

    private void CloseThis(GameObject obj)
    {
        gameObject.SetActive(false);
    }

    private void OnClickDefend(GameObject obj)
    {
        defendPage.SetActive(true);
    }

    private void OnClickMass(GameObject obj)
    {
        massPage.SetActive(true);
    }

    private void OnClickTelemetry(GameObject obj)
    {
        telemertyPage.SetActive(true);
    }

    private void OnClickPower(GameObject obj)
    {
        powerPage.SetActive(true);
    }

    private void OnClickMeteo(GameObject obj)
    {
        meteoPage.SetActive(true);
    }
}
