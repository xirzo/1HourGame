using Game.Domain.Inputs;
using UnityEngine;

namespace Game.Domain.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(IInput))]
    public class PlayerMovement : MonoBehaviour, IMoveable
    {
        public Vector2 Velocity => _rigidbody.linearVelocity;
        public bool IsMoving => _rigidbody.linearVelocity.magnitude > 0.01f;

        [SerializeField, Min(0)] private float _speed = 5f;

        private Rigidbody2D _rigidbody;
        private IInput _inputs;
        private Vector2 _movementInput;
        private Vector2 _movement;

        private void Awake()
        {
            TryGetComponent(out _rigidbody);
            TryGetComponent(out _inputs);
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _movementInput = _inputs.Movement;
            _movement = _movementInput * _speed * Time.deltaTime;
            _rigidbody.linearVelocity = _movement;
        }
    }
}
