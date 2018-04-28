using UnityEngine;
using CCG.Enums;

namespace CCG
{
    public static class Vector2ToDirection2D
    {
        public static Direction2D ToDirection2D(this Vector2 vector)
        {
            var x = vector.x;
            var y = vector.y;

            if (x == 0)
            {
                if (y < 0)
                {
                    return Direction2D.Down;
                }
                if (y == 0)
                {
                    return Direction2D.Neutral;
                }
                else if (y > 0)
                {
                    return Direction2D.Up;
                }
            }
            else if (x < 0)
            {
                if (y < 0)
                {
                    return Direction2D.DownLeft;
                }
                else if (y == 0)
                {
                    return Direction2D.Left;
                }
                else if (y > 0)
                {
                    return Direction2D.UpLeft;
                }
            }
            else if (x > 0)
            {
                if (y < 0)
                {
                    return Direction2D.DownRight;
                }
                else if (y == 0)
                {
                    return Direction2D.Right;
                }
                else if (y > 0)
                {
                    return Direction2D.UpRight;
                }
            }

            return Direction2D.None;
        }
    }
}