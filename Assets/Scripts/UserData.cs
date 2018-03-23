﻿namespace CCG
{
	public class UserData
	{
		public int TotalCoin { get; private set; }
		public int AddTotalCoin(int add) => TotalCoin += add;

		public PlayerModel PlayerModel { get; private set; }

		public static UserData LoadUserData()
		{
			var data = new UserData();
			data.TotalCoin = 0;

			return data;
		}
	}
}