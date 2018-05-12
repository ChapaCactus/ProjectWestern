using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace CCG.UI
{
    public static class UIManager
    {
		public static FadeCanvas FadeCanvas { get; private set; }

        private static readonly string CanvasPathHeader = "Prefabs/UI";

        public static void CreateTitleCanvas(Transform parent, Action<TitleCanvas> onCreate)
        {
			CreateCanvas<TitleCanvas>(TitleCanvas.PrefabName, parent, onCreate);
        }

        public static void CreateStageSelectCanvas(Transform parent, Action<StageSelectCanvas> onCreate)
        {
			CreateCanvas<StageSelectCanvas>(StageSelectCanvas.PrefabName, parent, onCreate);
        }

        public static void CreateStageCanvas(Transform parent, Action<StageCanvas> onCreate)
        {
			CreateCanvas<StageCanvas>(StageCanvas.PrefabName, parent, onCreate);
        }

		public static void CreateFadeCanvas(Transform parent, Action<FadeCanvas> onCreate)
		{
			CreateCanvas<FadeCanvas>(FadeCanvas.PrefabName, parent, onCreate);
		}

        public static void CreateStageSelectMap(int mapID, Transform parent, Action<StageSelectMap> onCreate)
        {
            var path = $"Prefabs/Stage/StageSelectMap/{StageSelectMap.PrefabNamePrefix}_{mapID.ToString("D3")}";
            Debug.Log(path);
            var prefab = Resources.Load(path) as GameObject;
            var map = GameObject.Instantiate(prefab, parent).GetComponent<StageSelectMap>();

            onCreate.SafeCall(map);
        }

		public static void SetFadeCanvas(FadeCanvas fadeCanvas)
		{
			Assert.IsNull(FadeCanvas);

			FadeCanvas = fadeCanvas;
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