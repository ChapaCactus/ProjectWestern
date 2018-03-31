using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
	public class BulletController : MonoBehaviour
	{
		public int Power => _master.Power;
		public int BaseSpeed => _master.BaseSpeed;

		public bool IsRunning { get; private set; } = false;
		public Vector3 MoveDir { get; private set; } = Vector2.zero;

		public Vector3 MoveSpeed => (MoveDir * (BaseSpeed * BaseSpeedBuff));

		private BulletMaster _master;

		private const float BaseSpeedBuff = 0.6f;
		private static readonly string PrefabPath = "Prefabs/Bullet/Bullet";

		private void Awake()
		{
			Assert.IsTrue(CompareTag("Bullet"));
		}

		private void Update()
		{
			if (!IsRunning) return;

			transform.position += MoveSpeed;
		}

		public static void Create(Transform parent, Action<BulletController> resFunc)
		{
			var prefab = Resources.Load(PrefabPath) as GameObject;
			var go = Instantiate(prefab, parent);
			var bullet = go.GetComponent<BulletController>();

			resFunc.SafeCall(bullet);
		}

		public void SetMaster(BulletMaster master)
		{
			_master = master;
		}

		public void Move(Vector2 startPos, Vector3 moveDir)
		{
			transform.position = startPos;
			MoveDir = moveDir;

			IsRunning = true;
		}

		public void Sleep()
		{
			IsRunning = false;
		}
	}
}