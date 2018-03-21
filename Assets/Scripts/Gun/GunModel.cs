using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
	public class GunModel
	{
		public GunID ID { get; private set; } = GunID.None;

		public GunShootType ShootType { get; private set; } = GunShootType.None;

		public float ShotInterval { get; private set; } = 1.0f;
	}
}