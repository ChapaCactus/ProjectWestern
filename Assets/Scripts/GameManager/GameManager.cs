using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCG.Master;
using CCG.Enums;
using UnityEngine.SceneManagement;

namespace CCG
{
    public static class GameManager
    {
        public static UserData UserData { get; private set; }
        public static StageMaster SelectedStageMaster { get; private set; }

        public static void StartGame()
        {
            Debug.Log("Game Started.");

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

        private static UserData LoadUserData()
        {
            return UserData.LoadUserData();
        }
    }
}