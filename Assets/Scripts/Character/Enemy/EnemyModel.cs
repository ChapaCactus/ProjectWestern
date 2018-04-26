using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace CCG
{
    public class EnemyModel
    {
        public EnemyModel(EnemyMaster master)
        {
            Name = master.Name;
            Health = master.Health;
            MoveSpeed = master.MoveSpeed;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public float MoveSpeed { get; set; }

        public bool IsDead => Health <= 0;

        public EnemyAIType AIType { get; private set; } = EnemyAIType.None;

        public ItemID[] DropItemIDs { get; private set; } = new ItemID[0];

        public ItemID GetDropItemIDAtRandom()
        {
            if (DropItemIDs == null) return ItemID.None;
            if (DropItemIDs.Length == 0) return ItemID.None;

            var random = UnityEngine.Random.Range(0, DropItemIDs.Length);
            return DropItemIDs[random];
        }
    }
}