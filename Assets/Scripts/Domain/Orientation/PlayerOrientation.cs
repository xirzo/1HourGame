using Game.Domain.Inputs;
using UnityEngine;

namespace Game.Domain.Orientation
{
    [RequireComponent(typeof(IInput))]
    public class PlayerOrientation : MonoBehaviour, IOrientation
    {
        public Vector2 ForwardDirection => _forwardDirection;
        [SerializeField, Min(0)] private float _raycastDistance = 5f;
        [SerializeField] private LayerMask _raycastLayers;
        private Transform _orientation;
        private IInput _inputs;
        private Vector2 _cursorPosition;
        private Vector2 _forwardDirection;

        private void Awake()
        {
            TryGetComponent(out _inputs);
            _orientation = transform;
        }

        private void Update()
        {
            CalculateForwardDirection();
        }

        private void CalculateForwardDirection()
        {
            _cursorPosition = Camera.main.ScreenToWorldPoint(_inputs.CursorPosition);
            _forwardDirection = _cursorPosition - (Vector2)transform.position;
        }

        public bool TryGetForwardCollider(out Collider2D collider)
        {
            RaycastHit2D hit = Physics2D.Raycast(_orientation.transform.position, _forwardDirection, _raycastDistance, _raycastLayers);

            if (hit == true)
            {
                collider = hit.collider;
                return true;
            }

            collider = null;
            return false;
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying == false)
            {
                return;
            }
                
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_orientation.transform.position, _cursorPosition);
        }
    }
}
