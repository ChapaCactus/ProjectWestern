using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CCG.Master;
using CCG.Enums;

namespace CCG
{
    public static class GameManager
    {
        public static readonly string UserData_SaveKey = "UserData";

        public static UserData UserData { get; private set; }
        public static StageMaster SelectedStageMaster { get; private set; }

        public static void StartGame()
        {
            Debug.Log("Game Started.");

            SaveUserData();
            UserData = LoadUserData();

            UIManager.I.UpdateTotalCoinText($"{UserData.TotalCoin}");
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
            UserData = new UserData();

            ES3.Save<UserData>(UserData_SaveKey, UserData);

            Debug.Log("SavedUserData.");
        }

        private static UserData LoadUserData()
        {
            Debug.Log("Loading UserData.");

            return ES3.Load<UserData>(UserData_SaveKey);
        }
    }
}