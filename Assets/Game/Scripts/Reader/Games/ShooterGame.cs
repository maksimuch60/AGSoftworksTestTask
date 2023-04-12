using System;
using System.Collections;
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
        WaitForSeconds _touchDelay = new WaitForSeconds(0.5f);

        public event Action<Vector2> OnTouchPressed; 

        private void Awake()
        {
            InputAction inputAction = playerInput.actions.FindAction("TouchPosition");
            _touch = inputAction;
        }

        private void OnEnable()
        {
            _touch.performed += IsTouchPressed;
        }
        
        private void OnDisable()
        {
            _touch.performed -= IsTouchPressed;
        }

        private void Start()
        {
            Debug.Log("[ShooterGame] Start");
        }

        private void IsTouchPressed(InputAction.CallbackContext context)
        {
            StartCoroutine(TouchDelay());
            Debug.Log("Touch");
            Vector2 touchPosition = context.ReadValue<Vector2>();
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            OnTouchPressed?.Invoke(worldPosition);
        }

        private IEnumerator TouchDelay()
        {
            _touch.performed -= IsTouchPressed;
            yield return _touchDelay;
            _touch.performed += IsTouchPressed;
        }
    }
}
