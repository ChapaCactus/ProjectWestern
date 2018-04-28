﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCG.Master;
using CCG.Enums;

namespace CCG
{
    public class StageSelect : SingletonMonoBehaviour<StageSelect>
    {
        private static readonly string MasterDirPath = "Master/Stage";

        public void OnSelectedStage(StageMaster selected)
        {
            GameManager.ChangeScene(SceneName.Stage);
        }

        public void LoadStageMaster(StageID id, Action<StageMaster> onLoad)
        {
            var path = $"{MasterDirPath}/{id}";
            var master = Resources.Load(path) as StageMaster;

            onLoad.SafeCall(master);
        }
    }
}