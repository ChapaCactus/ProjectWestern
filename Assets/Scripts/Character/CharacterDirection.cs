using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCG.Enums;

namespace CCG
{
    public class CharacterDirection
    {
        public Direction2D Current { get; private set; } = Direction2D.Neutral;
        public Vector2 Vector2 { get; private set; } = Vector2.zero;

        public void SetDirection(Vector2 vector)
        {
            Vector2 = vector;

            var dir = vector.ToDirection2D();
            SetDirection(dir);
        }

        private void SetDirection(Direction2D direction)
        {
            Current = direction;
        }
    }
}