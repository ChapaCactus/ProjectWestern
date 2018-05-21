using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using CCG.Master;

namespace CCG
{
    public static class GameManager
    {
        public static readonly string UserData_SaveKey = "UserData";

        public static bool IsGaming { get; private set; } = false;
        public static UserData UserData { get; private set; }
        public static StageMaster SelectedStageMaster { get; private set; }

        public static void StartGame()
        {
            Debug.Log("Game Started.");

            UserData = LoadUserData();
            UI.UIManager.UpdateTotalCoinText($"{UserData.TotalCoin}");
			UI.UIManager.CreateFadeCanvas(null, UI.UIManager.SetFadeCanvas);

            IsGaming = true;
            
			CallChangeScene(Enums.SceneName.Title, false);
        }

		public static void SetStageMaster(StageMaster master)
        {
            SelectedStageMaster = master;
        }
        
		public static void CallChangeScene(Enums.SceneName sceneName, bool isFade = true)
        {
			if (isFade)
			{
				UI.UIManager.FadeCanvas.FadeOut(() => ChangeScene(sceneName));
			} else
			{
				ChangeScene(sceneName);
			}
        }

		private static void ChangeScene(Enums.SceneName sceneName)
		{
			Debug.Log($"Start ChangeScene --> {sceneName}");
			UnityEngine.SceneManagement.SceneManager.LoadScene($"{sceneName}");
		}

        private static void SaveUserData()
        {
			Assert.IsNotNull(UserData);
			if (UserData == null) return;

            ES3.Save<UserData>(UserData_SaveKey, UserData);
        }

        private static UserData LoadUserData()
        {
            if (!ES3.KeyExists(UserData_SaveKey)) return new UserData();

            return ES3.Load<UserData>(UserData_SaveKey);
        }
    }
}