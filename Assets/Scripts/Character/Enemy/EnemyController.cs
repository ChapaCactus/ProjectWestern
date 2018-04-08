using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	[RequireComponent(typeof(EnemyView))]
	public class EnemyController : CharacterController
	{
		private static readonly string PrefabName = "Enemy";
		private static readonly string PrefabDirPath = "Prefabs/Enemy";

		public string Name => _model.Name;
		public bool IsSleep { get; private set; } = false;

		private EnemyModel _model { get; set; }
		private EnemyView _view { get; set; }

		private PlayerController _target { get; set; }

		private void Awake()
		{
			_view = GetComponent<EnemyView>();
		}

		private void LateUpdate()
		{
			if(_target != null)
			{
				Move(_target.transform.position);
			}
		}

		public static void Create(Transform parent, Action<EnemyController> onCreate)
		{
			var prefabPath = $"{PrefabDirPath}/{PrefabName}";
			var prefab = Resources.Load(prefabPath) as GameObject;
			var go = Instantiate(prefab, parent);

			var enemy = go.GetComponent<EnemyController>();

			onCreate.SafeCall(enemy);
		}

		public void Setup(EnemyMaster master)
		{
			_view.SetSprite(master.Sprites[0]);

			_model = new EnemyModel(master);
		}

		public void SetTarget(PlayerController player)
		{
			_target = player;
		}

		private void Move(Vector3 targetPos)
		{
			var dir = (targetPos - transform.position).normalized;
			transform.position += dir * (_model.MoveSpeed / 100);
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
	}
}