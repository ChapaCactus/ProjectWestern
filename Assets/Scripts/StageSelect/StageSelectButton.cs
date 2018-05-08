using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using CCG.Enums;
using CCG.Master;

namespace CCG
{
    public class StageSelectButton : MonoBehaviour
    {
        [SerializeField]
        private StageID _stageID = StageID.None;

        [SerializeField]
        private Button _button;

        [SerializeField]
        private Text _stageNumText;

        private StageSelectScene _stageSelect;
        private StageMaster _stageMaster;

        public StageID StageID => _stageID;

        private void Awake()
        {
            Assert.IsNotNull(_button);
            Assert.IsNotNull(_stageNumText);
        }

        public void Setup(StageSelectScene stageSelect)
        {
            _stageSelect = stageSelect;
            _stageNumText.text = $"{(int)_stageID}";
            LoadStageMaster(_stageID, master => _stageMaster = master);
            _button.onClick.AddListener(OnClick);
        }

        private void LoadStageMaster(StageID id, Action<StageMaster> onLoad)
        {
            _stageSelect.LoadStageMaster(id, onLoad);
        }

        private void OnClick()
        {
            Debug.Log($"OnClick StageID: {_stageID}, Master Title: {_stageMaster.Title}");

            _stageSelect.OnSelectedStage(_stageMaster);
        }
    }
}