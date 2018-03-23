using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public class BattleScene : SceneBase
	{
		[SerializeField]
		private StageMaster _debugStageMaster;

		private StageController _stage { get; set; }

		public void SetupStage(StageMaster master)
		{
			CreateStageController(stage => stage.Setup(master));
		}

		protected override void PrepareScene()
		{
			AddDispatchEvents();

			if(_debugStageMaster != null)
			{
				CreateStageController(stage => _stage = stage);
			}
		}

		private void AddDispatchEvents()
		{
		}

		private void CreateStageController(Action<StageController> onCreate)
		{
			StageController.Create(transform, onCreate.SafeCall);
		}
	}
}