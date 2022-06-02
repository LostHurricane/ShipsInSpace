using System;
using UnityEngine;

namespace ShipsInSpace
{
    public class InteractiveObjectView : MonoBehaviour, IView, ITransform, IRigidBody, ICollider, ISpriteRenderer, IDamagible, IArmed
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

        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        public SpriteRenderer SpriteRenderer { get => _spriteRenderer; set => _spriteRenderer = value; }

        [SerializeField]
        private Transform _weaponTransform;
        public Transform WeaponTransform { get => _weaponTransform; set => _weaponTransform = value; }


        public Action<IDamagible, int> OnDamageTaken { get; set; }


        public void TakeDamage(int damage)
        {
            OnDamageTaken.Invoke(this, damage);
        }
    }
}
