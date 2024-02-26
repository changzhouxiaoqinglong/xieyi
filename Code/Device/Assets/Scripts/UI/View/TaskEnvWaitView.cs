
using Spore.DataBinding;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 等待任务下发界面
/// </summary>
public class TaskEnvWaitView : ViewBase<TaskEvWaitViewModel>
{
    /// <summary>
    /// 文本
    /// </summary>
    private Text descText;

    /// <summary>
    /// 进度条
    /// </summary>
    private Image progressImage;

    /// <summary>
    /// 加载中
    /// </summary>
    private GameObject loadingText;

    /// <summary>
    /// 进度值
    /// </summary>
    private Text progressText;

    private bool haveGetTaskEnv;
    protected override void Awake()
    {
        base.Awake();
        descText = transform.Find("desc/Text").GetComponent<Text>();
        progressImage = transform.Find("progressBg/progress").GetComponent<Image>();
        loadingText = transform.Find("progressBg/loading").gameObject;
        progressText = transform.Find("progressBg/progressText").GetComponent<Text>();
        NetManager.GetInstance().AddNetMsgEventListener(ServerType.LocalServer, NetProtocolCode.TASK_ENV, OnGetTaskMsg);
    }

    /// <summary>
    /// 收到下发的任务环境信息
    /// </summary>
    private void OnGetTaskMsg(IEventParam param)
    {
        if (haveGetTaskEnv)
        {
            return;
        }
        Logger.Log("OnGetTaskMsg.");
        if (param is TcpReceiveEvParam tcpParam)
        {
            haveGetTaskEnv = true;
            TaskEnvVarData data = JsonTool.ToObject<TaskEnvVarData>(tcpParam.netData.Msg);
            NetVarDataMgr.GetInstance()._NetVarData._TaskEnvVarData = data;
            ViewModel.taskEnvVarData.Value = data;
            //场景数据
            ExSceneData sceneData = SceneExDataMgr.GetInstance().GetDataById(data.Scene);
            //加载场景
            StartCoroutine(ViewModel.LoadSceneAsyn(sceneData.SceneName));
        }
    }

    /// <summary>
    /// 更新任务环境信息
    /// </summary>
    [AutoBinding(BindConstant.UpTaskEnvVarData)]
    private void UpdateTaskEnvData(TaskEnvVarData oldValue, TaskEnvVarData newValue)
    {
        descText.text = newValue.GetDesc();
    }

    /// <summary>
    /// 更新场景加载进度
    /// </summary>
    [AutoBinding(BindConstant.UpTaskEnvSceneProgress)]
    private void UpdateSceneLoadProgress(float oldValue, float newValue)
    {
        loadingText.SetActive(true);
        progressText.text = Mathf.Floor(newValue * 100) + "%";
        progressImage.fillAmount = newValue;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        NetManager.GetInstance().RemoveNetMsgEventListener(ServerType.LocalServer, NetProtocolCode.TASK_ENV, OnGetTaskMsg);
    }
}