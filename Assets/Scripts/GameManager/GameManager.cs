using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	public static class GameManager
	{
		public static UserData UserData { get; private set; }

		public static void StartGame()
		{
			Debug.Log("Game Started.");

			LoadUserData();

			UIManager.I.UpdateTotalCoinText($"{UserData.TotalCoin}");
		}

		private static void LoadUserData()
		{
			UserData = UserData.LoadUserData();
		}
	}
}