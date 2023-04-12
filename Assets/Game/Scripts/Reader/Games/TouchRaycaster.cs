using System;
using UnityEngine;

namespace Game.Reader.Games
{
    public class TouchRaycaster : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private ShooterGame shooterGame;
        
        [Header("Values")]
        [SerializeField] private LayerMask _layerMask;

        public event Action OnTouched; 

        private void OnEnable()
        {
            shooterGame.OnTouchPressed += PerformRaycast;
        }
        
        private void OnDisable()
        {
            shooterGame.OnTouchPressed -= PerformRaycast;
        }

        private void PerformRaycast(Vector2 touchPosition)
        {
            int collisions = Physics2D.OverlapCircleNonAlloc(touchPosition, 1, null, _layerMask);
            if (collisions > 0)
            {
                OnTouched?.Invoke();
            }
        }
    }
}