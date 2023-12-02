using System;
using UnityEngine;

namespace Game.Domain.Inputs
{
    public interface IInput
    {
        event Action OnAttackPerformed;
        Vector2 Movement { get; }
        Vector2 CursorPosition { get; }
    }
}
