using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
	public class EntityContainer<T>
	{
		public EntityContainer()
		{
			Init();
		}

		public Queue<T> Entities { get; private set; }

		public bool IsEmpty => (Entities.Count == 0);

		public void Init()
		{
			Entities = new Queue<T>();
		}

		public void Set(T arg)
		{
			Entities.Enqueue(arg);
		}

		public T Pick()
		{
			return Entities.Dequeue();
		}
	}
}