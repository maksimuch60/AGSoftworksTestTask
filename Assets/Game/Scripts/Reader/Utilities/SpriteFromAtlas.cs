using System;
using UnityEngine;
using UnityEngine.U2D;

namespace Game.Reader.Utilities
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteFromAtlas : MonoBehaviour
    {
        [SerializeField] private SpriteAtlas spriteAtlas;
        [SerializeField] private Sprite sprite;

        private SpriteRenderer _spriteRenderer;
        private void Awake()
        { 
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = spriteAtlas.GetSprite(sprite.name);
        }
    }
}
