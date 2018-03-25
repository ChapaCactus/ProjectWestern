using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
	public class CharacterController : MonoBehaviour
	{
		public CharacterModel Model { get; private set; }

		public Transform Transform { get; private set; }
		public Rigidbody2D Rigid2D { get; private set; }

		private void Awake()
		{
			Transform = transform;
			Rigid2D = GetComponent<Rigidbody2D>();
		}

		public void Setup(CharacterModel model)
		{
			Model = model;
		}

		protected void Move(Vector2 moveDir)
		{
			Rigid2D.velocity = new Vector2(moveDir.x, moveDir.y);
		}
	}
}