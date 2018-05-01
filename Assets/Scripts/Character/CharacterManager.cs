using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class CharacterManager : SingletonMonoBehaviour<CharacterManager>
    {
        public PlayerController Player { get; private set; }
        public List<EnemyController> Enemies { get; private set; }

		private void Awake()
		{
            Reset();
		}

        public void CreateNewPlayer(Transform parent, Action<PlayerController> onCreate)
        {
            PlayerController.Create(parent, onCreate);
        }

        public void CreateNewEnemy(Transform parent, RoundMaster round, Action<EnemyController, EnemyMaster> onCreate)
        {
            round.GetEnemyMasterAtRandom(master =>
            {
                EnemyController.Create(parent, enemy => onCreate(enemy, master));
            });
        }

		public void SetPlayer(PlayerController player)
        {
            Player = player;
        }

        public void SetEnemy(EnemyController enemy)
        {
            Enemies.Add(enemy);
        }

        public void Reset()
        {
            Player = null;
            ClearEnemies();
        }

        public void ClearEnemies()
        {
            Enemies?.ForEach(enemy => Destroy(enemy.gameObject));
            Enemies = new List<EnemyController>();
        }
	}
}