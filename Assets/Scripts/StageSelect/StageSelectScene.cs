﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCG.Master;
using CCG.Enums;

namespace CCG
{
    public class StageSelectScene : SceneBase
    {
        private bool _isStageChanging = false;
        private StageSelectCanvas _canvas;

        private static readonly string MasterDirPath = "Master/Stage";

        protected override void PrepareScene()
        {
            _isStageChanging = false;

            UIManager.CreateStageSelectCanvas(transform, c => _canvas = c);
            UIManager.CreateStageSelectMap(1, _canvas.transform, map =>
            {
                var buttons = map.SearchStageSelectButtons();
                buttons.ForEach(button => button.Setup(this));
            });
        }

        public void OnSelectedStage(StageMaster selected)
        {
            if (_isStageChanging) return;

            _isStageChanging = true;
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