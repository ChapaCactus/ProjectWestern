using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace CCG
{
    public static class UIManager
    {
        private static readonly string CanvasPathHeader = "Prefabs/UI";
        private static readonly string TitleCanvasPrbName = "TitleCanvas";
        private static readonly string StageSelectCanvasPrbName = "StageSelectCanvas";
        private static readonly string StageCanvasPrbName = "StageCanvas";

        public static void CreateTitleCanvas(Transform parent, Action<TitleCanvas> onCreate)
        {
            CreateCanvas<TitleCanvas>(TitleCanvasPrbName, parent, onCreate);
        }

        public static void CreateStageSelectCanvas(Transform parent, Action<StageSelectCanvas> onCreate)
        {
            CreateCanvas<StageSelectCanvas>(StageSelectCanvasPrbName, parent, onCreate);
        }

        public static void CreateStageCanvas(Transform parent, Action<StageCanvas> onCreate)
        {
            CreateCanvas<StageCanvas>(StageCanvasPrbName, parent, onCreate);
        }

        public static void CreateStageSelectMap(int mapID, Transform parent, Action<StageSelectMap> onCreate)
        {
            var path = $"Prefabs/Stage/StageSelectMap/{StageSelectMap.PrefabNamePrefix}_{mapID.ToString("D3")}";
            Debug.Log(path);
            var prefab = Resources.Load(path) as GameObject;
            var map = GameObject.Instantiate(prefab, parent).GetComponent<StageSelectMap>();

            onCreate.SafeCall(map);
        }

        public static void Init()
        {
            Debug.Log("Start Initializing UI Manager.");
        }

        public static void UpdateTotalCoinText(string text)
        {
        }

        private static void CreateCanvas<T>(string prefabName, Transform parent, Action<T> onCreate)
        {
            var prefab = Resources.Load($"{CanvasPathHeader}/{prefabName}") as GameObject;
            var canvas = GameObject.Instantiate(prefab, parent).GetComponent<T>();

            onCreate.SafeCall(canvas);
        }
    }
}