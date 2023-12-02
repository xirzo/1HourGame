using System;
using Game.Domain.Combat.Health;
using UnityEngine;

namespace Game.Domain.Combat.Attacking
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        public event Action<IDamageable> OnHitDamageable;
        [SerializeField, Min(0)] private float _initialForce = 10f;
        [SerializeField] private Collider2D _collider;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            TryGetComponent(out _rigidbody);
        }

        public void Launch()
        {
            _rigidbody.AddForce(transform.up * _initialForce, ForceMode2D.Force);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            {
                OnHitDamageable?.Invoke(damageable);
                return;
            }

            Physics2D.IgnoreCollision(_collider, other.collider);
        }
    }
}
