﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CCG.Master;

namespace CCG
{
    public class StageInfoPanel : SceneContentBase
    {
        [System.Serializable]
        public class UIElement
        {
            [SerializeField]
            private Text _stageTitle;

            [SerializeField]
            private Text _areaName;

            [SerializeField]
            private Text _roundLength;

            [SerializeField]
            private Button _startStage;

            public Text StageTitle => _stageTitle;
            public Text AreaName => _areaName;
            public Text RoundLength => _roundLength;
            public Button StartStage => _startStage;
        }

        [SerializeField]
        private StageInfoPanel.UIElement _uiElement;

        public static readonly string PrefabPath = "Prefabs/UI/StageInfoPanel";

        public void Setup(StageMaster master)
        {
            _uiElement.StageTitle.text = master.Title;
            _uiElement.AreaName.text = master.Title;
            _uiElement.RoundLength.text = $"全{master.RoundCount} Round";
            _uiElement.StartStage.onClick.AddListener(OnStartClick);
        }

        private void OnStartClick()
        {
           // DispatchEvent();
        }
    }
}