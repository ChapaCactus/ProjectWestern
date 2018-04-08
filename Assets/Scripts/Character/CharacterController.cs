using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
	public class CharacterController : MonoBehaviour, IDamageable, IKillable
	{
		public Transform Transform { get; private set; }
		public Rigidbody2D Rigid2D { get; private set; }

		private CharacterModel _model { get; set; }

		private void Awake()
		{
			Transform = transform;
			Rigid2D = GetComponent<Rigidbody2D>();
		}

		public void Setup(CharacterModel model)
		{
			_model = model;
		}

		public void Damage(int taken)
		{
			_model.Damage(taken, Kill);
		}

		public void Kill()
		{
			Destroy(gameObject);
		}

		protected void Move(Vector2 moveDir)
		{
			Rigid2D.velocity = new Vector2(moveDir.x, moveDir.y);
		}
	}
}