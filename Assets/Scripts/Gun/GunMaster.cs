using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
	[CreateAssetMenu(menuName = "CreateMaster/GunMaster")]
	public class GunMaster : ScriptableObject
	{
		[SerializeField]
		private string _id;

		[SerializeField]
		private BulletMaster _bulletMaster;

		[SerializeField]
		private int _power = 1;

		[SerializeField]
		private int _shotSpeed = 1;

		[SerializeField]
		private float _shotSpan = 1;

		[SerializeField]
		private float _minShotSpanTime = 0.3f;

		[SerializeField]
		private int _oneshotBullets;

		[SerializeField]
		private Sprite _thumbnail;

		public int Power => _power;
		public int ShotSpeed => _shotSpeed;
		public float ShotSpan => _shotSpan;
		public float MinShotSpanTime => _minShotSpanTime;

		public Sprite Thumbnail => _thumbnail;
	}
}