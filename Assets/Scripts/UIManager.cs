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

        private void Awake()
        {
            Assert.IsNotNull(_totalCoinText);
            Assert.IsNotNull(_roundTimer);
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