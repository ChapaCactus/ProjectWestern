using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCG.Master;

namespace CCG
{
    public class StageScene : SceneBase
    {
        [SerializeField]
        private StageMaster _debugStageMaster;

        private StageMaster _stageMaster;
        private StageController _stageController;
        private StageCanvas _stageCanvas;

		public void SetupStage(StageMaster master)
        {
            _stageMaster = master;

            UIManager.CreateStageCanvas(transform, OnCreateCanvas);
            CharacterManager.Create(transform, manager => manager.Init());
        }

        protected override void PrepareScene()
        {
            GameManager.StartGame();

            AddDispatchEvents();

            if (_debugStageMaster != null)
            {
                SetupStage(_debugStageMaster);
            }
        }

        private void OnCreateCanvas(StageCanvas stageCanvas)
        {
            StageController.Create(transform, stage => stage.Setup(_stageMaster, stageCanvas));
        }

        private void AddDispatchEvents()
        {
            AddDispatchEvent<Action<StageCanvas>>("", GetStageCanvas);
        }

        private void GetStageCanvas(Action<StageCanvas> resfunc)
        {
            resfunc.SafeCall(_stageCanvas);
        }
    }
}