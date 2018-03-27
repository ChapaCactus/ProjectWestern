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

		public Vector3 GetRandomPos()
		{
			var point = _popPoints.OrderBy(p => Guid.NewGuid()) as PopPoint;
			return point.GetPosition();
		}
	}
}