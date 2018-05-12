using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using TMPro;
using DG.Tweening;

namespace CCG.UI
{
    public class TitleCanvas : MonoBehaviour
    {
        [SerializeField]
        private Button _titleScreenButton;

        [SerializeField]
        private TextMeshProUGUI _tapToStartText;

		public static readonly string PrefabName = "TitleCanvas";

		private void Awake()
		{
            Assert.IsNotNull(_titleScreenButton);
            Assert.IsNotNull(_tapToStartText);

            PlayTapToStartTextAnimation();
		}

		public void SetOnClickTitleScreen(Action onClick)
        {
            _titleScreenButton.onClick.AddListener(onClick.SafeCall);
        }

        private void PlayTapToStartTextAnimation()
        {
            _tapToStartText.alpha = 1;
            _tapToStartText.DOFade(0.3f, 1)
                           .SetLoops(-1, LoopType.Yoyo)
                           .SetDelay(0.7f)
                           .SetEase(Ease.InExpo);
        }
    }
}