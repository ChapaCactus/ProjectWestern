using UnityEngine;

namespace CCG
{
    public class TitleScene : SceneBase
    {
        private UI.TitleCanvas _titleCanvas;

		protected override void PrepareScene()
		{
			base.PrepareScene();
            
            UI.UIManager.CreateTitleCanvas(transform, c =>
            {
                _titleCanvas = c;
                c.SetOnClickTitleScreen(OnClickTitleScreen);
            });
		}

		protected override void StartScene()
		{
			base.StartScene();

			UI.UIManager.FadeCanvas.FadeIn(null);
		}

		protected override void AddDispatchEvents()
		{
		}

		protected override void PlayBGM()
		{
			DarkTonic.MasterAudio.MasterAudio.PlaySound("GB_01_Loop");
		}

		private void OnClickTitleScreen()
        {
            GameManager.CallChangeScene(Enums.SceneName.StageSelect);
        }
	}
}