using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

namespace CCG
{
    [RequireComponent(typeof(Slider))]
    public class RoundTimer : MonoBehaviour
    {
        private Slider _slider;
        private float _timer = 0;
        private Action _onEndTimer;

        public bool IsRunning => _timer > 0;

		private void Awake()
		{
            _slider = GetComponent<Slider>();
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

        public void StartTimer(float time, Action onEndTimer)
        {
            _timer = time;
            _slider.maxValue = time;
            _slider.minValue = 0;
            _slider.value = time;

            _onEndTimer = onEndTimer;
        }

        private void OnEndTimer()
        {
            _onEndTimer.SafeCall();
        }
    }
}