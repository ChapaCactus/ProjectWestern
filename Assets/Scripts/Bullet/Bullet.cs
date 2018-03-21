using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField]
		private float _speed = 1.0f;

		public Vector3 ShootDir { get; private set; } = Vector3.zero;
		// Cached Transform
		public Transform Transform { get; private set; }

		public bool IsPlaying { get; private set; } = false;

		public Vector3 MoveSpeed => ShootDir * (_speed * BaseSpeedBuff);

		private const float BaseSpeedBuff = 13.0f;

		private void Awake()
		{
			Transform = transform;

			Assert.IsTrue(CompareTag("Bullet"));
		}

		private void Update()
		{
			if (IsPlaying)
			{
				Transform.localPosition += MoveSpeed;
			}
		}

		public static void Create(Transform parent, Action<Bullet> onCreate)
		{
			var prefab = Resources.Load("") as GameObject;
			var go = Instantiate(prefab, parent);

			var bullet = go.GetComponent<Bullet>();

			onCreate.SafeCall(bullet);
		}

		public void Play(Vector2 shootDir)
		{
			ShootDir = shootDir;

			IsPlaying = true;
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void Hide()
		{
			IsPlaying = false;
			gameObject.SetActive(false);
		}

		[ContextMenu("DebugShoot")]
		public void DebugShoot()
		{
			Play(Vector2.up);
		}
	}
}