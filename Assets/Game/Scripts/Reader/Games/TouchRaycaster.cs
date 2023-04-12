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
            Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(touchPosition, 1, _layerMask);
            Debug.Log(collider2Ds.Length);
            for (int i = 0; i < collider2Ds.Length; i++)
            {
                if (collider2Ds[i].gameObject.CompareTag("Vedma"))
                {
                    OnTouched?.Invoke();
                }
            }
        }
    }
}