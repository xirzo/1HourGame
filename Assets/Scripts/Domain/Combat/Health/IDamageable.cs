
using System;

namespace Game.Domain.Combat.Health
{
    public interface IDamageable
    {
        event Action<float> OnHealed;
        event Action<float> OnDamaged;
        event Action OnDied;

        float Health { get; }
        float MaxHealth { get; }
        void Damage(float value);
        void Heal(float value);
        void Die();
    }
}
