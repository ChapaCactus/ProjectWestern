using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CCG
{
    public class StageCanvas : MonoBehaviour
    {
        [SerializeField]
        private Text _totalCoinText;

        [SerializeField]
        private RoundTimer _roundTimer;

        public Text TotalCoinText => _totalCoinText;
        public RoundTimer RoundTimer => _roundTimer;
    }
}