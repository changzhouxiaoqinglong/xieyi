﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExDataMgr : ExDataMgrBase<CarExDataMgr, ExCarData>
{
    /// <summary>
    /// 表名
    /// </summary>
    protected override string FILE_NAME { get; set; } = "CarData.txt";
}
