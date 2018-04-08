﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public class StageController : SceneContentBase
	{
		public int Round { get; private set; } = 0;
		public RoundMaster CurrentRoundData => _stageMaster.Rounds[Round];

		public PlayerController Player { get; private set; }
		public List<EnemyController> Enemies { get; private set; }

		[SerializeField]
		private Transform _playerParent;

		[SerializeField]
		private Transform _enemiesParent;

		private StageMaster _stageMaster;

		private GroundSetting _currentGround;

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

			CreateGround();

			ClearEnemies();

			CreateNewPlayer();
			CreateNewEnemy();
		}

		protected override void Prepare()
		{
			AddDispatchEvents();
		}

		private void AddDispatchEvents()
		{
		}

		private void CreateGround()
		{
			var prefab = CurrentRoundData.GroundSettingPrefab;
			var go = Instantiate(prefab, transform);

			var ground = go.GetComponent<GroundSetting>();
			_currentGround = ground;
		}

		private void CreateNewPlayer()
		{
			PlayerController.Create(_playerParent, OnCreatePlayer);
		}

		private void CreateNewEnemy()
		{
			CurrentRoundData.GetEnemyMasterAtRandom(master => {
				EnemyController.Create(_enemiesParent, enemy => OnCreateEnemy(enemy, master));
			});
		}

		private void OnCreatePlayer(PlayerController player)
		{
			var userData = GetUserData();
			player.Setup(userData);

			Player = player;
		}

		private void OnCreateEnemy(EnemyController enemy, EnemyMaster master)
		{
			var startPos = _currentGround.GetRandomPosition();
			enemy.transform.localPosition = startPos;
			enemy.Setup(master);
			enemy.SetTarget(Player);
		}

		private UserData GetUserData()
		{
			var data = GameManager.UserData;
			return data;
		}

		private void ClearEnemies()
		{
			Enemies?.ForEach(enemy => Destroy(enemy.gameObject));
			Enemies = new List<EnemyController>();
		}

		private void OnDeadEnemy(EnemyModel model)
		{
			Debug.Log($"{model.Name} is Dead.");
		}
	}
}