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

        private StageMaster _stageMaster;

        private void Awake()
        {
            Assert.IsNotNull(_button);
            Assert.IsNotNull(_stageNumText);

            _stageNumText.text = $"{(int)_stageID}";

            LoadStageMaster(_stageID, master => _stageMaster = master);

            _button.onClick.AddListener(OnClick);
        }

        private void LoadStageMaster(StageID id, Action<StageMaster> onLoad)
        {
            StageSelect.I.LoadStageMaster(id, onLoad);
        }

        private void OnClick()
        {
            Debug.Log($"OnClick StageID: {_stageID}, Master Title: {_stageMaster.Title}");

            StageSelect.I.OnSelectedStage(_stageMaster);
        }
    }
}