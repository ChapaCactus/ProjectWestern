using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
	public class GunController : MonoBehaviour
	{
		public Bullet Bullet { get; private set; }

		public GunID ID => _model.ID;
		public GunShootType ShootType => _model.ShootType;

		private GunModel _model { get; set; }

		private float _shotInterval;
		private bool CanShot => _shotInterval <= 0;

		private void Update()
		{
			
		}

		public void Setup(GunModel model)
		{
			_model = model;
		}

		public void Shoot()
		{
			Assert.IsNotNull(Bullet);

			if (Bullet == null) return;
		}

		private void SetBullet(Bullet bullet)
		{
			Bullet = bullet;
		}
	}
}