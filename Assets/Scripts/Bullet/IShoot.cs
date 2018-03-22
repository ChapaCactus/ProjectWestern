using UnityEngine;

namespace CCG
{
	public interface IShoot
	{
		void Shoot(BulletController bullet, Vector2 shootDir);
	}
}