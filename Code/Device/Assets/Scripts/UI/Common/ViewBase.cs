using Spore.DataBinding;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 关闭类型
/// </summary>
public enum CloseType
{
    /// <summary>
    /// 销毁
    /// </summary>
    Destroy,

    /// <summary>
    /// 隐藏
    /// </summary>
    Hide,
}

public class ViewBase<TViewModel> : UnityMono, IView where TViewModel : ViewModelBase, new()
{
    /// <summary>
    /// 面板类型
    /// </summary>
    public ViewType ViewType { get; set; }

    /// <summary>
    /// 关闭类型
    /// </summary>
    public CloseType closeType;

    public ViewBase()
    {
        BindingContext.ValueChanged += OnBindingContextChanged;
    }

    protected override void Awake()
    {
        base.Awake();
        //绑定ViewModel层
        ViewModel = new TViewModel();
    }

    #region Binding
    private List<BindingData> _currentBindingDatas = new List<BindingData>();

    /// <summary>
    /// View所绑定的ViewModel。
    /// </summary>
    private BindableProperty<TViewModel> BindingContext = new BindableProperty<TViewModel>();

    public TViewModel ViewModel
    {
        get
        {
            return BindingContext.Value;
        }
        set
        {
            BindingContext.Value = (TViewModel)value;
        }
    }

    protected virtual void OnBindingContextChanged(TViewModel oldViewModel, TViewModel newViewModel)
    {
        AutoBindingTool.Unbinding(_currentBindingDatas);
        AutoBindingTool.Binding(BindingContext.Value, this, _currentBindingDatas);
    }
    #endregion


    public virtual void Close()
    {
        switch (closeType)
        {
            case CloseType.Destroy:
                Destroy(gameObject);
                break;
            case CloseType.Hide:
                gameObject.SetActive(false);
                break;
        }
    }

    public virtual void OnOpen()
    {
        switch (closeType)
        {
            case CloseType.Destroy:
                break;
            case CloseType.Hide:
                gameObject.SetActive(true);
                break;
        }
    }
}