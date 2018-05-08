using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CCG
{
    public class TitleCanvas : MonoBehaviour
    {
        [SerializeField]
        private Button _titleScreenButton;

        public void SetOnClickTitleScreen(Action onClick)
        {
            _titleScreenButton.onClick.AddListener(onClick.SafeCall);
        }
    }
}