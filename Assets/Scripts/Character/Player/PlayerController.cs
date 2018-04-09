﻿using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public class PlayerController : CharacterController, IShoot
	{
		public CharacterDirection Direction { get; private set; } = new CharacterDirection();

		[SerializeField]
		private BulletController _bulletPrefab;

		private Action _callRestart;

		private PlayerModel _model { get; set; }

		private readonly float MoveBuff = 100f;

		private static readonly string PrefabPath = "Prefabs/Player/Player";

		private void Update()
		{
			var x = 0;
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			{
				x = 1;
			}
			else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			{
				x = -1;
			}

			var y = 0;
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			{
				y = 1;
			}
			else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			{
				y = -1;
			}

			var moveDir = new Vector2(x, y);
			Direction.SetDirection(moveDir);

			Move(Direction.Vector2 * MoveBuff);

			if(Input.GetButtonDown("Jump"))
			{
				CreateNewBullet(bullet => Shot(bullet, Direction.Vector2));
			}
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
	}
}