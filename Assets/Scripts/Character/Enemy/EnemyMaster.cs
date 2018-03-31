using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	[CreateAssetMenu(menuName = "CreateMaster/EnemyMaster")]
	public class EnemyMaster : ScriptableObject
	{
		[SerializeField]
		private string _name = "";

		[SerializeField]
		private List<Sprite> _sprites = new List<Sprite>();

		[SerializeField]
		private CharacterAnimation _characterAnimation;

		[SerializeField]
		private int _health = 1;

		[SerializeField]
		private int _moveSpeed = 100;

		public string Name => _name;
		public List<Sprite> Sprites => _sprites;
		public CharacterAnimation CharacterAnimation => _characterAnimation;
		public int Health => _health;
		public int MoveSpeed => _moveSpeed;
	}
}