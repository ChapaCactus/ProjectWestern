using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CCG.UI;

namespace CCG
{
    public class TitleScene : SceneBase
    {
        private TitleCanvas _titleCanvas;

		protected override void PrepareScene()
		{
			base.PrepareScene();

            UIManager.CreateTitleCanvas(transform, c =>
            {
                _titleCanvas = c;
                c.SetOnClickTitleScreen(OnClickTitleScreen);
            });
		}

		protected override void StartScene()
		{
			base.StartScene();

			UIManager.FadeCanvas.FadeIn(null);
		}

		protected override void AddDispatchEvents()
		{
		}

		private void OnClickTitleScreen()
        {
            GameManager.CallChangeScene(Enums.SceneName.StageSelect);
        }
	}
}