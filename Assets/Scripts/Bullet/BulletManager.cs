using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace CCG
{
	public class BulletManager : SingletonMonoBehaviour<BulletManager>
	{
		[SerializeField]
		private BulletController _bulletPrefab;

		[SerializeField]
		private Transform _bulletParent;

		public void CreateNewBullet(Action<BulletController> onCreate)
		{
			var go = Instantiate(_bulletPrefab, _bulletParent);
			var bullet = go.GetComponent<BulletController>();

			onCreate.SafeCall(bullet);
		}
	}
}