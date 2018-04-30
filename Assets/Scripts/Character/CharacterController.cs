using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class CharacterController : MonoBehaviour, IKillable
    {
        public CharacterDirection Direction { get; private set; } = new CharacterDirection();

        public Transform Transform { get; private set; }
        public Rigidbody2D Rigid2D { get; private set; }

        public bool CanMove { get; protected set; } = false;

        private readonly float MoveBuff = 100f;

        private void Awake()
        {
            Transform = transform;
            Rigid2D = GetComponent<Rigidbody2D>();
        }

        public void Kill()
        {
            Destroy(gameObject);
        }

        public void SetCanMove(bool canMove)
        {
            CanMove = canMove;
        }

        protected void Move(Vector2 movement)
        {
            if (!CanMove) return;

            Rigid2D.velocity = new Vector2(movement.x, movement.y) * MoveBuff;
            Direction.SetDirection(movement);
        }
    }
}