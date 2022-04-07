using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class InteractiveObjectView : MonoBehaviour, ITransform, IRigidBody, ICollider
    {
        [SerializeField]
        private Transform _transform;
        public Transform Transform { get => _transform; set => _transform = value; }

        [SerializeField]
        private Rigidbody2D _rigidbody;
        public Rigidbody2D Rigidbody { get => _rigidbody; set => _rigidbody = value; }

        [SerializeField]
        private Collider2D _collider;
        public Collider2D Collider { get => _collider; set => _collider = value; }

    }
}
