using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using CCG.Enums;

namespace CCG
{
    public class PlayerController : CharacterController, IDamageable, IKillable, IShoot
    {
        [SerializeField]
        private BulletController _bulletPrefab;
        [SerializeField]
        private BoxCollider2D _boxCollder;

        private Action _callRestart;
        private Action _onExitToNextGround;

        private static readonly string PrefabPath = "Prefabs/Player/Player";

        public bool IsInvincible { get; private set; }
        private PlayerModel _model { get; set; }

        private void Update()
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            var movement = new Vector2(h, v);
            Move(movement);

            CheckShotInput();
        }

        public static void Create(Transform parent, Action<PlayerController> onCreate)
        {
            var prefab = Resources.Load(PrefabPath) as GameObject;
            var go = Instantiate(prefab, parent);

            var player = go.GetComponent<PlayerController>();
            onCreate(player);
        }

        public void Setup(UserData userData)
        {
            SetIsTrigger(false);
        }

        public void Damage(int taken)
        {
            _model.Damage(taken, Kill);
        }

        public void Kill()
        {
        }

        public void SetIsTrigger(bool isTrigger)
        {
            _boxCollder.isTrigger = isTrigger;
        }

        public void SetInvincible(bool isInvincible)
        {
            IsInvincible = isInvincible;
            Assert.IsTrue(IsInvincible, $"{gameObject.name}は無敵状態です");
        }

        public void SetCallRestart(Action callRestart)
        {
            _callRestart = callRestart;
        }

        public void SetOnExitToNextGround(Action callback)
        {
            _onExitToNextGround = callback;
        }

        public void Shot(BulletController bullet, Vector2 moveDir)
        {
            var startPos = transform.position;
            bullet.Move(startPos, moveDir);
        }

        private void CreateNewBullet(Action<BulletController> onCreate)
        {
            var bulletID = BulletID.Bullet001;
            BulletManager.I.CreateBullet(bulletID, transform, onCreate);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var hitGO = collision.gameObject;
            if (hitGO.CompareTag("Enemy"))
            {
                if (IsInvincible)
                {
                    var enemy = collision.gameObject.GetComponent<EnemyController>();
                    enemy.Damage(10000);
                } else
                {
                    _callRestart.SafeCall();
                }
            } else if(hitGO.CompareTag("Exit"))
            {
                _onExitToNextGround.SafeCall();
            }
        }

        // J, L, I, Kキーで弾発射
        private void CheckShotInput()
        {
            var h = 0;
            if (Input.GetKeyDown(KeyCode.J))
            {
                h = -1;
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                h = 1;
            }

            var v = 0;
            if (Input.GetKeyDown(KeyCode.I))
            {
                v = 1;
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                v = -1;
            }

            if (h != 0 || v != 0)
            {
                var shotDir = new Vector2(h, v);
                CreateNewBullet(bullet => Shot(bullet, shotDir));
            }
        }
    }
}