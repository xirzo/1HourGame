using System;
using UnityEngine;

namespace Game.Domain.Inputs
{
    public class PlayerInputs : MonoBehaviour, IInput
    {
        public event Action OnAttackPerformed;
        public Vector2 Movement => _movement;
        public Vector2 CursorPosition => _cursor;
        private Vector2 _movement;
        private Vector2 _cursor;
        private InputActions _actions;

        private void Awake()
        {
            _actions = new InputActions();
            _actions.Player.Attack.performed += context => OnAttackPerformed?.Invoke();
        }

        private void OnDestroy()
        {
            _actions.Player.Attack.performed -= context => OnAttackPerformed?.Invoke();
        }

        private void Update()
        {
            _movement = _actions.Player.Movement.ReadValue<Vector2>();
            _cursor = _actions.Player.Cursor.ReadValue<Vector2>();
        }

        private void OnEnable()
        {
            _actions.Enable();
        }

        private void OnDisable()
        {
            _actions.Disable();
        }
    }
}
