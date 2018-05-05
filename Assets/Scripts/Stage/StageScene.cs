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
        private CharacterManager _characterManager;

		public void SetupStage(StageMaster master)
        {
            _stageMaster = master;

            StageController.Create(transform, stage => stage.Setup(_stageMaster));
        }

        protected override void PrepareScene()
        {
            AddDispatchEvents();

            UIManager.CreateStageCanvas(transform, c => _stageCanvas = c);
            CharacterManager.Create(transform, c => _characterManager = c);

            if (_debugStageMaster != null)
            {
                SetupStage(_debugStageMaster);
            }
        }

		protected override void StartScene()
		{
            _characterManager.Init();
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