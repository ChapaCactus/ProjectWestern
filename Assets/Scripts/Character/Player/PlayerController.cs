using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public class PlayerController : CharacterController, IShoot
	{
		[SerializeField]
		private BulletController _bulletPrefab;

		private PlayerModel _model { get; set; }

		private readonly float MoveBuff = 100f;

		private static readonly string PrefabPath = "Prefabs/Player/Player";

		private void Update()
		{
			var h = 0;
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
				h = 1;
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
				h = -1;

			var v = 0;
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
				v = 1;
			if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
				v = -1;

			Move(h * MoveBuff, v * MoveBuff);

			if(Input.GetButtonDown("Jump"))
			{
				var bullet = Instantiate(_bulletPrefab, transform).GetComponent<BulletController>();
				bullet.transform.localPosition = Vector3.zero;
				Shoot(bullet, Vector2.up);
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

		public void Shoot(BulletController bullet, Vector2 shootDir)
		{
			bullet.Play(shootDir);
		}
	}
}