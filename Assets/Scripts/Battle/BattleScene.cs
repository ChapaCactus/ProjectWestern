using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public class BattleScene : SceneBase
	{
		private StageMaster _stageMaster { get; set; }

		public void SetupStage(StageMaster master)
		{
			_stageMaster = master;
		}

		protected override void PrepareScene()
		{
			AddDispatchEvents();
		}

		private void AddDispatchEvents()
		{
		}
	}
}