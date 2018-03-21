using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public class PlayerController : CharacterController, IShoot
	{
		private readonly float MoveBuff = 100f;

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

		public void Shoot(Bullet bullet, Vector2 shootDir)
		{
			bullet.Play(shootDir);
		}
	}
}