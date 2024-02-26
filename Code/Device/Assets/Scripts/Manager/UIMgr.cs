using System.Collections.Generic;
using UnityEngine;
public enum ViewType
{
    LoginView,
    TaskEnvWaiView
}

public class UIMgr : MonoSingleTon<UIMgr>
{
    private List<IView> openViews = new List<IView>();
    /// <summary>
    /// ui面板父节点
    /// </summary>
    private Transform uiRoot;

    private void Awake()
    {
        uiRoot = GameObject.Find("UI/Canvas/UIRoot").transform;
    }

    /// <summary>
    /// 打开面板
    /// </summary>
    /// <param name="type">面板类型</param>
    public IView OpenView(ViewType type)
    {
        IView curOpenView = GetViewByType(type);
        //已经打开了
        if (curOpenView != null)
        {
            return curOpenView;
        }
        string viewName = type.ToString();
        IView openView;
        Transform haveView = uiRoot.Find(viewName);
        //对应面板已存在 不用重新生成
        if (haveView)
        {
            haveView.SetAsLastSibling();
            openView = haveView.GetComponent<IView>();
        }
        else
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("UI/View/" + viewName), uiRoot);
            obj.name = obj.name.Replace("(Clone)", string.Empty);
            openView = obj.GetComponent<IView>();
        }
        openView.ViewType = type;
        openView.OnOpen();
        openViews.Add(openView);
        return openView;
    }

    /// <summary>
    /// 关闭面板
    /// </summary>
    public void CloseView(ViewType type)
    {
        IView closeView = GetViewByType(type);
        if (closeView != null)
        {
            openViews.Remove(closeView);
            closeView.Close();
        }
    }

    /// <summary>
    /// 关闭所有面板
    /// </summary>
    public void CloseAllViews()
    {
        for (int i = openViews.Count - 1; i >= 0; i--)
        {
            CloseView(openViews[i].ViewType);
        }
    }

    /// <summary>
    /// 根据面板类型 获得当前打开的对应的面板
    /// </summary>
    public IView GetViewByType(ViewType uiType)
    {
        if (openViews.Count > 0)
        {
            foreach (IView item in openViews)
            {
                if (item.ViewType == uiType)
                {
                    return item;
                }
            }
        }
        return null;
    }

    public void ShowToast(string tip)
    {
        //GameObject toastObj = Resources.Load<GameObject>("UI/Item/Common/Toast");
        //Toast toast = Instantiate(toastObj, toastRoot).GetComponent<Toast>();
        //toast.ShowTip(tip);
    }
}
