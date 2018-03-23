﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public class EnemyController : CharacterController
	{
		public bool IsSleep { get; private set; } = false;

		private EnemyModel _model;

		private Action<EnemyModel> _onDead;

		private static readonly string PrefabName = "Enemy";
		private static readonly string PrefabDirPath = "Prefabs/Enemy";

		public static void Create(Transform parent, Action<EnemyController> onCreate)
		{
			var prefabPath = $"{PrefabDirPath}/{PrefabName}";
			var prefab = Resources.Load(prefabPath) as GameObject;
			var go = Instantiate(prefab, parent);

			var enemy = go.GetComponent<EnemyController>();

			onCreate.SafeCall(enemy);
		}

		public void Setup(EnemyMaster master, Action<EnemyModel> onDead)
		{
			_model = new EnemyModel(master);

			_onDead = onDead;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if(collision.CompareTag("Bullet"))
			{
				var bullet = collision.GetComponent<BulletController>();
				var power = bullet.Power;
				Damage(power);
			}
		}

		private void Damage(int power)
		{
			_model.Health -= power;

			if (_model.IsDead)
			{
				IsSleep = true;

				_onDead.SafeCall(_model);
			}
		}
	}
}