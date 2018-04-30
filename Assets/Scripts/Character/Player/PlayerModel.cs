using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class PlayerModel
    {
        public int Health { get; set; }

        public bool IsDead => (Health <= 0);

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