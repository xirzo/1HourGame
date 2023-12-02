using System;
using Game.Domain.Combat.Health;
using Game.Domain.Inputs;
using UnityEngine;

namespace Game.Domain.Combat.Attacking
{
    [RequireComponent(typeof(IInput))]
    public class PlayerAttacker : MonoBehaviour, IAttacker
    {
        public event Action<IDamageable> OnAttacked;
        public float Damage => _damage;
        [SerializeField, Min(0)] private float _damage = 25f;
        [SerializeField] private Transform _projectileSpawnpoint;
        [SerializeField] private Projectile _projectilePrefab;
        private IInput _inputs;

        private void Awake()
        {
            TryGetComponent(out _inputs);

            _inputs.OnAttackPerformed += TryAttack;
        }

        private void OnDestroy()
        {
            _inputs.OnAttackPerformed -= TryAttack;
        }

        private Projectile SpawnProjectile()
        {
            return Instantiate(_projectilePrefab, _projectileSpawnpoint.position, _projectileSpawnpoint.rotation);
        }

        private void TryAttack()
        {
            var projectile = SpawnProjectile();
            projectile.Launch();
            projectile.OnHitDamageable += OnProjectileHit;
        }

        private void OnProjectileHit(IDamageable damageable)
        {
            Attack(damageable);
        }

        public void Attack(IDamageable target)
        {
            target.Damage(_damage);
            OnAttacked?.Invoke(target);
        }

        public void SetDamage(float value)
        {
            if (value < 0)
            {
                _damage = 0;
                return;
            }

            _damage = value;
        }
    }
}
