using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
	public class CharacterAnimation : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _renderer;

		[SerializeField]
		private Animator _animator;

		public void Play(string stateName)
		{
			_animator.Play(stateName);
		}
	}
}