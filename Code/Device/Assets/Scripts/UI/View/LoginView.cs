
using UnityEngine;
using UnityEngine.UI;

public class LoginView : ViewBase<LoginViewModel>
{
    private InputField userName;

    private InputField password;

    protected override void Awake()
    {
        base.Awake();
        userName = transform.Find("UserName").GetComponent<InputField>();
        password = transform.Find("Password").GetComponent<InputField>();
        ButtonBase button = transform.Find("loginBtn").GetComponent<ButtonBase>();
        button.RegistClick(OnClickLoginBtn);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        NetManager.GetInstance().AddNetMsgEventListener(ServerType.LocalServer, NetProtocolCode.LOGIN, OnLoginRes);
    }

    private void OnClickLoginBtn(GameObject obj)
    {
        if (!NetManager.GetInstance().IsConnected(ServerType.LocalServer))
        {
            UIMgr.GetInstance().ShowToast("服务器未连接，无法登录");
        }
        else
        {
            //请求登录
            LoginModel loginModel = new LoginModel()
            {
                UserName = userName.text,
                PassWord = password.text,
            };
            NetManager.GetInstance().SendMsg(ServerType.LocalServer, JsonTool.ToJson(loginModel), NetProtocolCode.LOGIN);
        }
    }

    //登录结果
    private void OnLoginRes(IEventParam param)
    {
        Logger.Log("OnLoginRes");
        if (param is TcpReceiveEvParam tcpParam)
        {
            LoginRes loginRes = JsonTool.ToObject<LoginRes>(tcpParam.netData.Msg);
            //登录成功
            if (loginRes.IsSuccess())
            {
                Logger.Log("LoginSuccess." + loginRes.UserName);
                NetVarDataMgr.GetInstance()._NetVarData._UserInfo = new UserInfo()
                {
                    userName = loginRes.UserName
                };
                //关闭界面 打开任务下发界面
                Close();
                UIMgr.GetInstance().OpenView(ViewType.TaskEnvWaiView);
            }
            //登录失败
            else
            {
                Logger.LogWarning("LoginFaile:" + loginRes.Code);
            }
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        NetManager.GetInstance().RemoveNetMsgEventListener(ServerType.LocalServer, NetProtocolCode.LOGIN, OnLoginRes);
    }
}
