using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
	public class GroundSetting : MonoBehaviour
	{
		[SerializeField]
		private List<PopPoint> _popPoints = new List<PopPoint>();

		private void Awake()
		{
			Assert.IsNotNull(_popPoints);
		}

		public Vector3 GetRandomPosition()
		{
			var point = _popPoints.Where(p => p.IsRunning).OrderBy(p => Guid.NewGuid()) as PopPoint;
			return point.GetPosition();
		}
	}
}