using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using CCG.Enums;

namespace CCG
{
    public class BulletManager : SingletonMonoBehaviour<BulletManager>
    {
        [SerializeField]
        private BulletController _bulletPrefab;

        private List<BulletMaster> _bulletMasters;
        private EntityContainers<BulletID, BulletController> _pooledBullets;

        private const string MasterDirPath = "Resources/Master/Bullet";

        private void Awake()
        {
            Init();
        }

        public void CreateBullet(BulletID id, Transform parent, Action<BulletController> onCreate)
        {
            BulletMaster master = SearchBulletMaster(id);

            EntityContainer<BulletController> container = _pooledBullets.GetContainer(id);
            BulletController bullet = TryGetPooledBullet(container);

            if (bullet == null)
            {
                var go = Instantiate(_bulletPrefab, parent);
                bullet = go.GetComponent<BulletController>();
            }

            bullet.SetMaster(master);
            container.Set(bullet);

            onCreate.SafeCall(bullet);
        }

        public void CreateBullet(BulletMaster master, Transform parent, Action<BulletController> onCreate)
        {
            CreateBullet(master.ID, parent, onCreate);
        }

        private void Init()
        {
            _bulletMasters = CollectMasters();
            _pooledBullets = new EntityContainers<BulletID, BulletController>();
        }

        private BulletMaster SearchBulletMaster(BulletID id)
        {
            if (_bulletMasters == null) return null;

            return _bulletMasters.FirstOrDefault(master => master.ID == id);
        }

        private BulletController TryGetPooledBullet(EntityContainer<BulletController> container)
        {
            if (container == null) return null;
            if (container.IsEmpty) return null;

            return container.Pick();
        }

        private List<BulletMaster> CollectMasters()
        {
            var dir = new DirectoryInfo($"{Application.dataPath}/{MasterDirPath}");
            FileInfo[] files = dir.GetFiles("*.asset");
            var names = files.Select(file => file.Name.Replace(file.Extension, ""));
            var masters = names.Select(name => Resources.Load($"Master/Bullet/{name}") as BulletMaster).ToList();

            return masters;
        }
    }
}