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

		private static readonly string PrefabPath = "Prefabs/Stage/Stage";

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

		private void CreateNewPlayer()
		{
			PlayerController.Create(transform, OnCreatePlayer);
		}

		private void CreateNewEnemy()
		{
			CurrentRoundData.GetEnemyMasterAtRandom(master => {
				EnemyController.Create(transform, enemy => OnCreateEnemy(enemy, master));
			});
		}

		private void OnCreatePlayer(PlayerController player)
		{
			GetPlayerData(data => player.Setup(data));
		}

		private void OnCreateEnemy(EnemyController enemy, EnemyMaster master)
		{
			enemy.Setup(master);
		}

		private void GetPlayerData(Action<PlayerData> resfunc)
		{
			var data = new PlayerData();
			resfunc.SafeCall(data);
		}
	}
}