using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
	public abstract class SceneBase : MonoBehaviour, IDispatchEventHandler
	{
		private Dictionary<string, object> _dispatchEvents = new Dictionary<string, object>();

		private void Awake()
		{
			if (!GameManager.IsGaming)
			{
				GameManager.StartGame();
			}
			else
			{
				PrepareScene();
			}
		}

		private void Start()
		{
			StartScene();
		}

		public void AddDispatchEvent(string key, Action action)
		{
			if (_dispatchEvents == null) return;
			if (_dispatchEvents.ContainsKey(key)) return;

			_dispatchEvents.Add(key, action);
		}

		public void AddDispatchEvent<T>(string key, Action<T> action)
		{
			if (_dispatchEvents == null) return;
			if (_dispatchEvents.ContainsKey(key)) return;

			_dispatchEvents.Add(key, action);
		}

		public void AddDispatchEvent<T1, T2>(string key, Action<T1, T2> action)
		{
			if (_dispatchEvents == null) return;
			if (_dispatchEvents.ContainsKey(key)) return;

			_dispatchEvents.Add(key, action);
		}

		public void DispatchEvent(string key)
		{
			Assert.IsNotNull(_dispatchEvents);
			if (_dispatchEvents == null) return;
			Assert.IsTrue(_dispatchEvents.ContainsKey(key));
			if (!_dispatchEvents.ContainsKey(key)) return;

			var action = _dispatchEvents[key] as Action;
			action();
		}

		public void DispatchEvent<T>(string key, T param)
		{
			if (_dispatchEvents == null) return;
			if (!_dispatchEvents.ContainsKey(key)) return;

			var action = _dispatchEvents[key] as Action<T>;
			action(param);
		}

		public void DispatchEvent<T1, T2>(string key, T1 param1, T2 param2)
		{
			if (_dispatchEvents == null) return;
			if (!_dispatchEvents.ContainsKey(key)) return;

			var action = _dispatchEvents[key] as Action<T1, T2>;
			action(param1, param2);
		}

		protected virtual void PrepareScene()
		{
			AddDispatchEvents();
		}

		protected virtual void StartScene() { }
		protected abstract void AddDispatchEvents();
	}
}