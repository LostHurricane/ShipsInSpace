using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class ProjectileView : MonoBehaviour, ITransform, IRigidBody, ICollider, IDamageDealer, IPoolable
    {
        [SerializeField]
        private GameObject _gameObject;
        public GameObject GameObject { get => _gameObject; set => _gameObject = value; }

        [SerializeField]
        private Transform _transform;
        public Transform Transform { get => _transform; set => _transform = value; }

        [SerializeField]
        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        [SerializeField]
        private Collider2D _collider;
        public Collider2D Collider { get => _collider; set => _collider = value; }

        public Action<Transform> OnReturnToPool { get; set; }
        public Action<IDamagible> OnDealingDamage { get; set; }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.TryGetComponent<IDamagible>(out var target))
            {
                OnDealingDamage.Invoke(target);
                ReturnToPool();
            }
        }

        public void ReturnToPool()
        {
            OnReturnToPool.Invoke(transform);
        }
    }
}
