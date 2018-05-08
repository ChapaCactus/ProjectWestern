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

		private void Awake()
		{
            var buttons = FindObjectsOfType<StageSelectButton>();
            _stageSelectButtons = new List<StageSelectButton>(buttons);
            _stageSelectButtons.OrderBy(b => b.StageID);
		}
	}
}