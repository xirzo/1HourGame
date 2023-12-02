using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Domain.Movement
{
    public interface IMoveable
    {
        Vector2 Velocity { get; }
        bool IsMoving { get; }
    }
}
