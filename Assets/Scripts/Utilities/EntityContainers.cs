using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
	public class EntityContainers<T1, T2>
	{
		public EntityContainers()
		{
			Init();
		}

		private Dictionary<T1, EntityContainer<T2>> _containers { get; set; }

		public void Init()
		{
			_containers = new Dictionary<T1, EntityContainer<T2>>();
		}

		public EntityContainer<T2> GetContainer(T1 key)
		{
			if (!_containers.ContainsKey(key)) return null;

			return _containers[key];
		}

		public void CreateNewContainer(T1 key)
		{
			if (_containers.ContainsKey(key)) return;

			var container = new EntityContainer<T2>();
			_containers.Add(key, container);
		}
	}
}