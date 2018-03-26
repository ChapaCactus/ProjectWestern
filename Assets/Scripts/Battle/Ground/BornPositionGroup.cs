using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace CCG
{
	[Serializable]
	public class BornPositionGroup
	{
		[SerializeField]
		private List<Transform> _bornPosList = new List<Transform>();

		public Vector3 GetRandomPos()
		{
			var randomTF = _bornPosList.OrderBy(index => Guid.NewGuid()) as Transform;
			return randomTF.localPosition;
		}
	}
}