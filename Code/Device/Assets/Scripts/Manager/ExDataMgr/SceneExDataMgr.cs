﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExDataMgr : ExDataMgrBase<SceneExDataMgr, ExSceneData>
{
    /// <summary>
    /// 表名
    /// </summary>
    protected override string FILE_NAME { get; set; } = "SceneData.txt";
}
