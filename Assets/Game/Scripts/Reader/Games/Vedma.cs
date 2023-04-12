using UnityEngine;
using UnityEngine.U2D;

namespace Game.Reader.Games
{
    public class Vedma : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private TouchRaycaster touchRaycaster;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private SpriteAtlas spriteAtlas;
        [SerializeField] private Sprite[] sprites;
        
        [Header("Settings:")]
        [SerializeField] private int lives;

        private void OnEnable()
        {
            touchRaycaster.OnTouched += ApplyDamage;
        }

        private void OnDisable()
        {
            touchRaycaster.OnTouched -= ApplyDamage;
        }

        private void ApplyDamage()
        {
            lives--;
            spriteRenderer.sprite = spriteAtlas.GetSprite(sprites[^lives].name);
        }
    }
}