using System;
using Game.Domain.Combat.Health;
using UnityEngine;

namespace Game.Domain.Combat.Attacking
{
    public interface IAttacker
    {
        event Action<IDamageable> OnAttacked;
        float Damage { get; }
        void SetDamage(float value);
        void Attack(IDamageable target);
    }
}
