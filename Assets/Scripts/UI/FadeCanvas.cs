using System.Collections;
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

			public float Alpha => _image.color.a;

			public Fade(Image image, float start, float end)
			{
				_image = image;
				_start = start;
				_end = end;

				SetAlpha(0);
			}

			public void Play(System.Action onComplete)
			{
				ResetAlpha();
				_image.DOFade(_end, 1)
				      .SetEase(Ease.Linear)
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
        
		[SerializeField]
        private Image _fadeImage;

		private Fade _fadeOut;
		private Fade _fadeIn;

		public static readonly string PrefabName = "FadeCanvas";

		private void Awake()
		{
			DontDestroyOnLoad(this);
			_fadeOut = new Fade(_fadeImage, 0, 1);
			_fadeIn = new Fade(_fadeImage, 1, 0);
		}

		public void FadeOutIn(System.Action onComplete)
		{
			if (_fadeOut == null || _fadeIn == null) return;

			FadeOut(() => FadeIn(onComplete));
		}

		public void FadeOut(System.Action onComplete)
        {
			if (_fadeOut == null) return;
			if (_fadeOut.Alpha == 1) return;
            
			_fadeOut.Play(onComplete);
        }

		public void FadeIn(System.Action onComplete)
        {
			if (_fadeIn == null) return;
			if (_fadeIn.Alpha == 0) return;
            
			_fadeOut.SetAlpha(0);
			_fadeIn.Play(onComplete);
        }
    }
}