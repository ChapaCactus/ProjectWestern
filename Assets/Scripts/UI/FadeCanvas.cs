﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace CCG.UI
{
    public class FadeCanvas : MonoBehaviour
    {
        public class Fade
		{
			private Image _image;
			private float _start;
			private float _end;

			public Fade(Image image, float start, float end)
			{
				_image = image;
				_start = start;
				_end = end;

				SetAlpha(0);
			}

			public void Play(System.Action onComplete)
			{
				Debug.Log($"Play Fading... [start {_start}, end {_end}");
				ResetAlpha();
				_image.DOFade(_end, 1)
					  .OnComplete(onComplete.SafeCall);
			}

			public void SetAlpha(float alpha)
			{
				_image.color = new Color(_image.color.r, _image.color.g, _image.color.b, alpha);
			}

            private void ResetAlpha()
			{
				SetAlpha(_start);
			}
		}

        public enum State
        {
            Hide,
            FadeIn,
            FadeOut,
        }


		[SerializeField]
		private Image _fadeInImage;
		[SerializeField]
		private Image _fadeOutImage;

		private State _currentState = State.Hide;
		private Fade _fadeIn;
		private Fade _fadeOut;

		public static readonly string PrefabName = "FadeCanvas";

		private void Awake()
		{
			DontDestroyOnLoad(this);
			_fadeIn = new Fade(_fadeInImage, 0, 1);
			_fadeOut = new Fade(_fadeOutImage, 1, 0);
		}

		public void FadeInOut(System.Action onComplete)
		{
			FadeIn(() => FadeOut(onComplete));
		}

		public void FadeIn(System.Action onComplete)
        {
			if (_fadeIn == null) return;
			_fadeIn.Play(onComplete);
        }

		public void FadeOut(System.Action onComplete)
        {
			if (_fadeOut == null) return;

			_fadeIn.SetAlpha(0);
			_fadeOut.Play(onComplete);
        }

        private void OnEndFadeIn()
		{
			_currentState = State.Hide;
		}

        private void OnEndFadeOut()
		{
			_currentState = State.Hide;
		}
    }
}