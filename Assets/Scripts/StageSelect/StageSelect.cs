using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCG.Master;
using CCG.Enums;

namespace CCG
{
    public class StageSelect : MonoBehaviour
    {
        private static readonly string MasterDirPath = "Master/Stage";

        public void OnSelectedStage(StageMaster selected)
        {
        }

        private void LoadStageMaster(StageID id, Action<StageMaster> onLoad)
        {
            var path = $"{MasterDirPath}/{id}";
            var master = Resources.Load(path) as StageMaster;

            onLoad.SafeCall(master);
        }
    }
}