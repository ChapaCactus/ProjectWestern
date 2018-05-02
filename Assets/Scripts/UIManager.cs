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
        private static readonly string StageCanvasPrefabName = "StageCanvas";

        public static void CreateStageCanvas(Transform parent, Action<StageCanvas> onCreate)
        {
            var prefab = Resources.Load($"{CanvasPathHeader}/{StageCanvasPrefabName}") as GameObject;
            var canvas = Instantiate(prefab, parent).GetComponent<StageCanvas>();

            onCreate.SafeCall(canvas);
        }

        public void Init()
        {
            Debug.Log("Start Initializing UI Manager.");
        }

        public void UpdateTotalCoinText(string text)
        {
        }
    }
}