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
        private Action _onEndTimer;

        public float Timer { get; private set; }

        public bool IsOver => Timer <= 0;

		private void Awake()
		{
            _slider = GetComponent<Slider>();
            Assert.IsNotNull(_slider);
		}

		private void Update()
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
                _slider.value = Timer;

                if (Timer <= 0)
                {
                    Timer = 0;
                    OnEndTimer();
                }
            }
        }

        public void StartTimer(float time, Action onEndTimer)
        {
            Timer = time;
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