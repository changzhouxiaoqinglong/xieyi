
using UnityEngine;

public class AppMain : MonoBehaviour
{
    private void Awake()
    {
        InitConfigs();
    }
    private void Start()
    {
        //登录服务器
        NetManager.GetInstance().ConnectServer(ServerType.LocalServer);
    }

    private void InitConfigs()
    {
        NetConfig.InitConfig();
        AppConfig.InitConfig();
    }
}
