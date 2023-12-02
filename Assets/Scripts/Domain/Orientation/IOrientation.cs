using UnityEngine;

namespace Game.Domain.Orientation
{
    public interface IOrientation
    {
        Vector2 ForwardDirection { get; }
        bool TryGetForwardCollider(out Collider2D collider);
    }
}
