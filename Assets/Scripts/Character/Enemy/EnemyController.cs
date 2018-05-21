using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    [RequireComponent(typeof(EnemyView))]
    public class EnemyController : CharacterController, IDamageable, IKillable
    {
        private Action _onKilled;

        private static readonly string PrefabName = "Enemy";
        private static readonly string PrefabDirPath = "Prefabs/Enemy";

        public string Name => _model.Name;
        public bool IsSleep { get; private set; } = false;
        public bool IsDead => _model.IsDead;

        private EnemyModel _model { get; set; }
        private EnemyView _view { get; set; }

        private PlayerController _target { get; set; }

        private void Awake()
        {
            _view = GetComponent<EnemyView>();
        }

        private void LateUpdate()
        {
            Move();
        }

        public static void Create(Transform parent, Action<EnemyController> onCreate)
        {
            var prefabPath = $"{PrefabDirPath}/{PrefabName}";
            var prefab = Resources.Load(prefabPath) as GameObject;
            var enemy = Instantiate(prefab, parent).GetComponent<EnemyController>();
            onCreate.SafeCall(enemy);
        }

        public void Setup(EnemyMaster master)
        {
			Assert.IsNotNull(_view);

			if (_view != null)
			{
				_view.SetSprite(master.Sprites[0]);
			}

            _model = new EnemyModel(master);
        }

        public void SetOnKilledCallback(Action onKilled)
        {
            _onKilled = onKilled;
        }

        public void Damage(int taken)
        {
			if (_model == null) return;

            _model.Damage(taken, Kill);
        }

        public void Kill()
        {
            _onKilled.SafeCall();
            gameObject.SetActive(false);
        }

        public void SetTarget(PlayerController player)
        {
            _target = player;
        }

		private void Move()
        {
            if (_target == null) return;

			var dir = (_target.transform.position - transform.position).normalized;
            transform.position += dir * (_model.MoveSpeed / 100);
        }
    }
}