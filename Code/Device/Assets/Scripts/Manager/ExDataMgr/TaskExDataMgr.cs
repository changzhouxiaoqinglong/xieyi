/// <summary>
/// 任务表数据管理
/// </summary>
public class TaskExDataMgr : ExDataMgrBase<TaskExDataMgr, ExTaskData>
{
    /// <summary>
    /// 表名
    /// </summary>
    protected override string FILE_NAME { get; set; } = "TaskData.txt";

    public TaskExDataMgr() : base()
    {
        
    }
}
