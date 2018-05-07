using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace CCG
{
    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        private static readonly string CanvasPathHeader = "Prefabs/UI";
        private static readonly string TitleCanvasPrefabName = "TitleCanvas";
        private static readonly string StageCanvasPrefabName = "StageCanvas";

        public static void CreateTitleCanvas(Transform parent, Action<TitleCanvas> onCreate)
        {
            CreateCanvas<TitleCanvas>(TitleCanvasPrefabName, parent, onCreate);
        }

        public static void CreateStageCanvas(Transform parent, Action<StageCanvas> onCreate)
        {
            CreateCanvas<StageCanvas>(StageCanvasPrefabName, parent, onCreate);
        }

        public void Init()
        {
            Debug.Log("Start Initializing UI Manager.");
        }

        public void UpdateTotalCoinText(string text)
        {
        }

        private static void CreateCanvas<T>(string prefabName, Transform parent, Action<T> onCreate)
        {
            var prefab = Resources.Load($"{CanvasPathHeader}/{prefabName}") as GameObject;
            var canvas = Instantiate(prefab, parent).GetComponent<T>();

            onCreate.SafeCall(canvas);
        }
    }
}