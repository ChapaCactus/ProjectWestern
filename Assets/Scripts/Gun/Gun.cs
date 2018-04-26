using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
    public class Gun
    {
        private GunMaster _gunMaster;
        private BulletMaster _bulletMaster;
        private float _shotSpanTimer = 0;

        public int Power => _gunMaster.Power;
        public int ShotSpeed => _gunMaster.ShotSpeed;
        public float ShotSpan => _gunMaster.ShotSpan;

        private void Update()
        {
            if (_shotSpanTimer > 0)
            {
                _shotSpanTimer -= Time.deltaTime;
            }
        }

        public void Setup(GunMaster master)
        {
            Assert.IsNotNull(master);

            _gunMaster = master;
        }

        public void Shoot()
        {
            if (_bulletMaster == null) return;

            SetTimer(ShotSpan);
        }

        private void SetBullet(BulletMaster master)
        {
            Assert.IsNotNull(master);

            _bulletMaster = master;
        }

        private void SetTimer(float time)
        {
            _shotSpanTimer = time;

            if (_shotSpanTimer <= _gunMaster.MinShotSpanTime)
            {
                _shotSpanTimer = _gunMaster.MinShotSpanTime;
            }
        }
    }
}