using UnityEngine;

namespace CCG
{
	public interface IShoot
	{
		void Shoot(Bullet bullet, Vector2 shootDir);
	}
}