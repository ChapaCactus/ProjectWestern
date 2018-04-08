using System;

using UnityEngine;

namespace CCG
{
	public class CharacterModel
	{
		public bool IsPlayer { get; private set; }
		public bool IsDead => (Health <= 0);

		public int MaxHealth { get; private set; }
		public int Health { get; private set; }

		public ItemID DropItemID { get; private set; } = ItemID.None;

		public CharacterModel(bool isPlayer, int maxHealth)
		{
			IsPlayer = isPlayer;

			MaxHealth = maxHealth;
			Health = maxHealth;
		}

		public void Damage(int point, Action onDead)
		{
			Health -= point;

			if (IsDead)
			{
				onDead.SafeCall();
			}
		}
	}
}