using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace CCG
{
	public class UIManager : SingletonMonoBehaviour<UIManager>
	{
		[SerializeField]
		private Text _totalCoinText;

		private void Awake()
		{
			Assert.IsNotNull(_totalCoinText);
		}

		public void Init()
		{
			Debug.Log("Start Initializing UI Manager.");
		}

		public void UpdateTotalCoinText(string text)
		{
			_totalCoinText.text = text;
		}
	}
}