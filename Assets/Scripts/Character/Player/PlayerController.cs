using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCG.Enums;

namespace CCG
{
    public class PlayerController : CharacterController, IShoot
    {
        [SerializeField]
        private BulletController _bulletPrefab;

        private Action _callRestart;

        private PlayerModel _model { get; set; }

        private static readonly string PrefabPath = "Prefabs/Player/Player";

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
        }

        public void SetCallRestart(Action callRestart)
        {
            _callRestart = callRestart;
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
            if (collision.gameObject.CompareTag("Enemy"))
            {
                _callRestart.SafeCall();
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