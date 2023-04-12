using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Reader.Games
{
    /// <summary>
    /// Simple shooter mini-game
    /// </summary>
    public class ShooterGame : MonoBehaviour
    {
        [Header("References:")]
        [SerializeField] private PlayerInput playerInput;

        private InputAction _touch = new();

        public event Action<Vector2> OnTouchPressed; 

        private void Awake()
        {
            InputAction inputAction = playerInput.actions.FindAction("TouchPosition");
            _touch = inputAction;
        }

        private void OnEnable()
        {
            _touch.started += IsTouchPressed;
        }
        
        private void OnDisable()
        {
            _touch.started -= IsTouchPressed;
        }

        private void Start()
        {
            Debug.Log("[ShooterGame] Start");
        }

        private void IsTouchPressed(InputAction.CallbackContext context)
        {
            Vector2 touchPosition = context.ReadValue<Vector2>();
            OnTouchPressed?.Invoke(touchPosition);
        }
    }
}
