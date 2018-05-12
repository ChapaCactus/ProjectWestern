using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CCG.UI
{
    public class StageCanvas : MonoBehaviour
    {
        [SerializeField]
        private Text _totalCoinText;

        [SerializeField]
        private RoundTimer _roundTimer;

		public static readonly string PrefabName = "StageCanvas";

        public Text TotalCoinText => _totalCoinText;
        public RoundTimer RoundTimer => _roundTimer;
    }
}