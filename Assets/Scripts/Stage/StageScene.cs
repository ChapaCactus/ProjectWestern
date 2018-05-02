﻿using System;
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
        private CharacterManager _characterManager;

		public void SetupStage(StageMaster master)
        {
            _stageMaster = master;

            UIManager.CreateStageCanvas(transform, c => _stageCanvas = c);
            StageController.Create(transform, stage => stage.Setup(_stageMaster));
            CharacterManager.Create(transform, OnCreateCharacterManager);
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

        private void OnCreateCharacterManager(CharacterManager manager)
        {
            _characterManager = manager;
            manager.Init();
        }

        private void AddDispatchEvents()
        {
            AddDispatchEvent<Action<StageCanvas>>(StageEvents.RequestStageCanvas, RequestStageCanvas);
            AddDispatchEvent<Action<CharacterManager>>(StageEvents.RequestCharacterManager, RequestCharacterManager);
        }

        private void RequestStageCanvas(Action<StageCanvas> resfunc)
        {
            resfunc.SafeCall(_stageCanvas);
        }

        private void RequestCharacterManager(Action<CharacterManager> resfunc)
        {
            resfunc.SafeCall(_characterManager);
        }
    }
}