using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CCG
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _renderer;

        public void SetSprite(Sprite sprite)
        {
            _renderer.sprite = sprite;
        }
    }
}