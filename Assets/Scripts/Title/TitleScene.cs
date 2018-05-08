using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class TitleScene : SceneBase
    {
        private TitleCanvas _titleCanvas;

		protected override void PrepareScene()
		{
            UIManager.CreateTitleCanvas(transform, c =>
            {
                _titleCanvas = c;
                c.SetOnClickTitleScreen(OnClickTitleScreen);
            });
		}

        private void OnClickTitleScreen()
        {
            GameManager.ChangeScene(Enums.SceneName.StageSelect);
        }
	}
}