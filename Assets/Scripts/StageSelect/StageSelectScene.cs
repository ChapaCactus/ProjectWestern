using System;
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
        private StageInfoPanel _stageInfoPanel;

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
            CreateStageInfoPanel(c => _stageInfoPanel = c);
        }

        public void OnSelectedStage(StageMaster selected)
        {
        }

        public void LoadStageMaster(StageID id, Action<StageMaster> onLoad)
        {
            var path = $"{MasterDirPath}/{id}";
            var master = Resources.Load(path) as StageMaster;

            onLoad.SafeCall(master);
        }

        private void AddDispatchEvents()
        {
            AddDispatchEvent(StageSelectEvents.OnClickStart, OnClickStart);
        }

        private void OnClickStart()
        {
            if (_isStageChanging) return;

            _isStageChanging = true;
            GameManager.ChangeScene(SceneName.Stage);
        }

        private void CreateStageInfoPanel(Action<StageInfoPanel> onCreate)
        {
            var prefab = Resources.Load(StageInfoPanel.PrefabPath) as GameObject;
            var stageInfo = Instantiate(prefab, _canvas.transform).GetComponent<StageInfoPanel>();
            stageInfo.gameObject.SetActive(false);

            onCreate.SafeCall(stageInfo);
        }
    }
}