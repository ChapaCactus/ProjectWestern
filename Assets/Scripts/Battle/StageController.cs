using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public class StageController : MonoBehaviour
	{
		public int Round { get; private set; } = 0;
		public RoundMaster CurrentRoundData => _stageMaster.Rounds[Round];

		private StageMaster _stageMaster;

		private static readonly string PrefabPath = "Prefabs/Stage/StageController";

		public static void Create(Transform parent, Action<StageController> onCreate)
		{
			var prefab = Resources.Load(PrefabPath) as GameObject;
			var go = Instantiate(prefab, parent);

			var controller = go.GetComponent<StageController>();
			onCreate.SafeCall(controller);
		}

		public void Setup(StageMaster master)
		{
			_stageMaster = master;
		}

		private void CreateNewEnemy()
		{
			CurrentRoundData.GetEnemyMasterAtRandom(master => {
				EnemyController.Create(master, transform, OnCreateEnemy);
			});
		}

		private void OnCreateEnemy(EnemyController controller)
		{
		}
	}
}