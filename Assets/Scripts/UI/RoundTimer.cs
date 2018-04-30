using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace CCG
{
    public class RoundTimer : MonoBehaviour
    {
        [SerializeField]
        private Slider _slider;

        private float _timer = 0;

		private void Awake()
		{
            Assert.IsNotNull(_slider);
		}

		private void Update()
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                _slider.value = _timer;

                if (_timer <= 0)
                {
                    _timer = 0;
                    OnEndTimer();
                }
            }
        }

        public void StartTimer(float time)
        {
            _timer = time;
            _slider.maxValue = time;
            _slider.minValue = 0;
            _slider.value = time;
        }

        private void OnEndTimer()
        {
        }
    }
}