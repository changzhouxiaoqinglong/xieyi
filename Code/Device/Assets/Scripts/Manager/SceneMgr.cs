﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMgr : SingleTonBase<SceneMgr>
{
    public SceneCtrBase curScene;

    public void SetCurScene(SceneCtrBase curScene)
    {
        this.curScene = curScene;
    }
}
