using Game.Domain.Orientation;
using UnityEngine;

namespace Game.Domain.Rotation
{
    [RequireComponent(typeof(IOrientation))]
    public class PlayerRotation : MonoBehaviour, IRotator
    {
        private IOrientation _orientation;

        private void Awake()
        {
            TryGetComponent(out _orientation);
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            transform.up = _orientation.ForwardDirection;
        }
    }
}
