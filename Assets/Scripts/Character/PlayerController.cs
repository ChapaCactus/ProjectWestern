using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public class PlayerController : CharacterController, IShoot
	{
		private UserData _userData { get; set; }

		private readonly float MoveBuff = 100f;

		private static readonly string PrefabPath = "Prefabs/Player/Player";

		private void Update()
		{
			var h = Input.GetAxis("Horizontal");
			var v = Input.GetAxis("Vertical");

			var normalizedH = 0;
			var normalizedV = 0;

			if(h != 0)
			{
				normalizedH = h < 0 ? -1 : 1;
			}

			if (v != 0)
			{
				normalizedV = v < 0 ? -1 : 1;
			}

			Move(normalizedH * MoveBuff, normalizedV * MoveBuff);
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
			_userData = userData;
		}

		public void Shoot(BulletController bullet, Vector2 shootDir)
		{
			bullet.Play(shootDir);
		}
	}
}