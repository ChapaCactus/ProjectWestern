using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public class EnemyController : CharacterController
	{
		private EnemyModel _enemyModel;

		private static readonly string PrefabName = "Enemy";
		private static readonly string PrefabDirPath = "Prefabs/Enemy";

		public static void Create(EnemyMaster master, Transform parent, Action<EnemyController> onCreate)
		{
			var prefabPath = $"{PrefabDirPath}/{PrefabName}";
			var prefab = Resources.Load(prefabPath) as GameObject;
			var go = Instantiate(prefab, parent);

			var enemy = go.GetComponent<EnemyController>();
			enemy.Setup(master);

			onCreate.SafeCall(enemy);
		}

		public void Setup(EnemyMaster master)
		{
			_enemyModel = new EnemyModel(master);
		}
	}
}