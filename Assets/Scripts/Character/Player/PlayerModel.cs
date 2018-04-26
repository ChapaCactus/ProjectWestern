using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
    public class PlayerModel
    {
        public int Health { get; set; }

        public bool IsDead => (Health <= 0);
    }
}