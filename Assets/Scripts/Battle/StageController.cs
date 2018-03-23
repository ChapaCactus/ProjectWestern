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

		public PlayerController Player { get; private set; }
		public List<EnemyController> Enemies { get; private set; }

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

			ClearEnemies();

			CreateNewPlayer();
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
			var playerData = GetPlayerData();
			player.Setup(playerData);

			Player = player;
		}

		private void OnCreateEnemy(EnemyController enemy, EnemyMaster master)
		{
			enemy.Setup(master);
		}

		private PlayerData GetPlayerData()
		{
			var data = new PlayerData();
			return data;
		}

		private void ClearEnemies()
		{
			Enemies.ForEach(enemy => Destroy(enemy.gameObject));
			Enemies = new List<EnemyController>();
		}
	}
}