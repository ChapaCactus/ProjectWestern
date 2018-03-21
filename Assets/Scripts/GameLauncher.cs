using UnityEngine;

namespace CCG
{
	public class GameLauncher : MonoBehaviour
	{
		private void Awake()
		{
			GameManager.StartGame();
		}
	}
}