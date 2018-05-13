using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CCG.Master;

namespace CCG
{
    [RequireComponent(typeof(CanvasGroup))]
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

        private CanvasGroup _canvasGroup;

        public static readonly string PrefabPath = "Prefabs/UI/StageInfoPanel";

		protected override void Prepare()
		{
			base.Prepare();

            Close();
		}

		public void Setup(StageMaster master)
        {
            _uiElement.StageTitle.text = master.Title;
            _uiElement.AreaName.text = master.Title;
            _uiElement.RoundLength.text = $"全{master.RoundCount} Round";
            _uiElement.StartStage.onClick.AddListener(OnStartClick);
        }

		protected override void AddDispatchEvents()
		{
			AddDispatchEvent<StageMaster>(StageSelectEvents.OpenStageInfo, Open);
            AddDispatchEvent(StageSelectEvents.CloseStageInfo, Close);
            AddDispatchEvent(StageSelectEvents.OnStartClick, OnStartClick);
		}

		private void OnStartClick()
        {
            DispatchEvent(StageSelectEvents.OnStartClick);
        }

        private void Open(StageMaster master)
        {
            Setup(master);

            if(_canvasGroup == null) _canvasGroup = GetComponent<CanvasGroup>();

            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        private void Close()
        {
            if (_canvasGroup == null) _canvasGroup = GetComponent<CanvasGroup>();

            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}