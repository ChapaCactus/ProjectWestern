using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CCG.Master;
using CCG.Enums;
using CCG.UI;

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
            UIManager.UpdateTotalCoinText($"{UserData.TotalCoin}");
			UIManager.CreateFadeCanvas(null, c => {});

            IsGaming = true;

            ChangeScene(SceneName.Title);
        }

        public static void SetStageMaster(StageMaster master)
        {
            SelectedStageMaster = master;
        }

        public static void ChangeScene(SceneName stageName)
        {
            SceneManager.LoadScene($"{stageName}");
        }

        private static void SaveUserData()
        {
            ES3.Save<UserData>(UserData_SaveKey, UserData);
        }

        private static UserData LoadUserData()
        {
            if (!ES3.KeyExists(UserData_SaveKey)) return new UserData();

            return ES3.Load<UserData>(UserData_SaveKey);
        }
    }
}