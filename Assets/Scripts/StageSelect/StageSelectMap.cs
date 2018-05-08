using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CCG
{
    public class StageSelectMap : MonoBehaviour
    {
        private List<StageSelectButton> _stageSelectButtons;

        public static readonly string PrefabNamePrefix = "StageSelectMap";

        public List<StageSelectButton> SearchStageSelectButtons()
        {
            var buttons = GetComponentsInChildren<StageSelectButton>();
            _stageSelectButtons = new List<StageSelectButton>(buttons);

            return _stageSelectButtons;
        }
	}
}