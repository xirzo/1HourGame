using System;
using UnityEngine;

namespace Game.Domain.Combat.Health
{
    public class EntityHealth : MonoBehaviour, IDamageable
    {
        public event Action<float> OnHealed;
        public event Action<float> OnDamaged;
        public event Action OnDied;
        public float Health => _health;
        public float MaxHealth => _maxHealth;

        [SerializeField, Min(0)] private float _health = 100;
        [SerializeField, Min(0)] private float _maxHealth = 100;

        private void Awake()
        {
            if (_health > _maxHealth)
            {
                _health = _maxHealth;
                throw new Exception("Health value is bigger than max health!");
            }
        }

        public void Damage(float value)
        {
            if (_health - value <= 0)
            {
                _health = 0;
                OnDamaged?.Invoke(_health);
                Die();
                return;
            }

            _health -= value;

            OnDamaged?.Invoke(_health);
        }

        public void Heal(float value)
        {
            if (_health + value >= _maxHealth)
            {
                _health = _maxHealth;

                OnHealed?.Invoke(_health);

                return;
            }

            _health += value;
            OnHealed?.Invoke(_health);
        }
        public void Die()
        {
            gameObject.SetActive(false);
            OnDied?.Invoke();
        }
    }
}
