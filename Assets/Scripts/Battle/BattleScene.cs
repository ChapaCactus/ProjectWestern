using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public class BattleScene : SceneBase
	{
		private List<EnemyController> _enemyList { get; set; } = new List<EnemyController>();

		private StageController _stage { get; set; }

		public void SetupStage(StageMaster master)
		{
			CreateStageController(stage => stage.Setup(master));
		}

		protected override void PrepareScene()
		{
			AddDispatchEvents();
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