using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace CCG
{
	[CreateAssetMenu]
	public class RoundMaster : ScriptableObject
	{
		[SerializeField]
		private Sprite _backgroundSprite;

		[SerializeField]
		private Sprite _wallSprite;

		public Sprite BackgroundSprite => _backgroundSprite;
		public Sprite WallSprite => _wallSprite;
	}
}