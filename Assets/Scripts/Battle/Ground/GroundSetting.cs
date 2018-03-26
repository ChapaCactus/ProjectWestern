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
		private BornPositionGroup _enemyBornPosGroup = new BornPositionGroup();
	}
}