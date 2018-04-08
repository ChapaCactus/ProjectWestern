using UnityEngine;

namespace CCG
{
	public interface IShoot
	{
		void Shot(BulletController bullet, Vector2 shootDir);
	}
}