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

        private StageController _stageController;

		public void SetupStage(StageMaster master)
        {
            CharacterManager.Create(transform, manager => manager.Init());
            StageController.Create(transform, stage => stage.Setup(master));
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

        private void AddDispatchEvents()
        {
        }
    }
}