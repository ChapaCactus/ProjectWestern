using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace CCG
{
	public class BossRound : RoundTargetBase
	{
		[SerializeField]
		private EnemyMaster _target;

		private List<EnemyController> _killedEnemies = new List<EnemyController>();

		public void OnKilledEnemy(EnemyController enemy)
		{
			_killedEnemies.Add(enemy);
			CheckClear();
		}

		protected override void CheckClear()
		{
			var isBossKilled = _killedEnemies.Any(enemy => enemy.Name == _target.Name);
			if(isBossKilled)
			{
				OnClear();
			}
		}
	}
}