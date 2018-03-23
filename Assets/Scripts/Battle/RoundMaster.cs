using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace CCG
{
	[CreateAssetMenu]
	public class RoundMaster : ScriptableObject
	{
		[SerializeField]
		private List<EnemyMaster> _popEnemies = new List<EnemyMaster>();

		[SerializeField]
		private Sprite _backgroundSprite;

		[SerializeField]
		private Sprite _wallSprite;

		public Sprite BackgroundSprite => _backgroundSprite;
		public Sprite WallSprite => _wallSprite;

		public void GetEnemyMasterAtRandom(Action<EnemyMaster> resfunc)
		{
			if (_popEnemies == null) return;

			var enemyMaster = _popEnemies.OrderBy(enemy => System.Guid.NewGuid()) as EnemyMaster;
			resfunc.SafeCall(enemyMaster);
		}
	}
}