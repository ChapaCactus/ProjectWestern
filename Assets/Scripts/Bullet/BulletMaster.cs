﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
	[CreateAssetMenu(menuName = "CreateMaster/BulletMaster")]
	public class BulletMaster : ScriptableObject
	{
		public int Power => _power;
		public int BaseSpeed => _baseSpeed;

		public Sprite Sprite => _sprite;

		[SerializeField]
		private int _power = 1;

		[SerializeField]
		private int _baseSpeed = 100;

		[SerializeField]
		private Sprite _sprite;
	}
}