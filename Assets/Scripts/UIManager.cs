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
        [SerializeField]
        private Text _totalCoinText;

        [SerializeField]
        private RoundTimer _roundTimer;

        public RoundTimer RoundTimer => _roundTimer;

        private static readonly string CanvasPathHeader = "Prefabs/UI";
        private static readonly string StageCanvasPrefabName = "StageCanvas";

        private void Awake()
        {
            Assert.IsNotNull(_totalCoinText);
            Assert.IsNotNull(_roundTimer);
        }

        public static void CreateStageCanvas(Transform parent, Action<Canvas> onCreate)
        {
            var prefab = Resources.Load($"{CanvasPathHeader}/{StageCanvasPrefabName}") as GameObject;
            var canvas = Instantiate(prefab, parent).GetComponent<Canvas>();

            onCreate.SafeCall(canvas);
        }

        public void Init()
        {
            Debug.Log("Start Initializing UI Manager.");
        }

        public void UpdateTotalCoinText(string text)
        {
            _totalCoinText.text = text;
        }
    }
}