using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
	[CreateAssetMenu(menuName = "CreateMaster/BulletMaster")]
	public class BulletMaster : ScriptableObject
	{
		public int Power => _power;
		public int Speed => _speed;

		public Sprite Sprite => _sprite;

		[SerializeField]
		private int _power = 1;

		[SerializeField]
		private int _speed = 100;

		[SerializeField]
		private Sprite _sprite;
	}
}