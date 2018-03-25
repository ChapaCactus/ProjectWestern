using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public abstract class RoundTargetBase : ScriptableObject
	{
		private Action _onClear;

		public void SetClearCallback(Action onClear)
		{
			_onClear = onClear;
		}

		protected abstract void CheckClear();

		protected void OnClear()
		{
			_onClear.SafeCall();
		}
	}
}