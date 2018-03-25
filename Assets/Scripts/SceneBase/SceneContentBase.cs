using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

namespace CCG
{
	public class SceneContentBase : MonoBehaviour
	{
		private SceneBase _sceneBase = null;

		private void Awake()
		{
			FindSceneParent();

			Prepare();
		}

		public Transform GetSceneParent(Transform parent)
		{
			var higherParent = parent.parent;

			if(higherParent != null)
			{
				// 再帰的呼び出し
				return GetSceneParent(higherParent);
			} else
			{
				return parent;
			}
		}

		protected virtual void Prepare()
		{
		}

		private void FindSceneParent()
		{
			var parent = transform.parent;
			var sceneParent = GetSceneParent(parent).GetComponent<SceneBase>();
			_sceneBase = sceneParent;
		}

		protected void AddDispatchEvent(string key, Action action)
		{
			if (_sceneBase == null) return;

			_sceneBase.AddDispatchEvent(key, action);
		}

		protected void AddDispatchEvent<T>(string key, Action<T> action)
		{
			if (_sceneBase == null) return;

			_sceneBase.AddDispatchEvent(key, action);
		}

		protected void AddDispatchEvent<T1, T2>(string key, Action<T1, T2> action)
		{
			if (_sceneBase == null) return;

			_sceneBase.AddDispatchEvent(key, action);
		}

		protected void DispatchEvent(string key)
		{
			if (_sceneBase == null) return;

			_sceneBase.DispatchEvent(key);
		}

		protected void DispatchEvent<T>(string key, T param)
		{
			if (_sceneBase == null) return;

			_sceneBase.DispatchEvent(key, param);
		}

		protected void DispatchEvent<T1, T2>(string key, T1 param1, T2 param2)
		{
			if (_sceneBase == null) return;

			_sceneBase.DispatchEvent(key, param1, param2);
		}
	}
}