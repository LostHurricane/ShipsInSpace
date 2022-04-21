using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class RigidBodyMovement : IMove
    {
        public float Speed { get; protected set; }

        private Rigidbody2D _rigidbody;
        private Vector3 _movementVector;

        public RigidBodyMovement (Rigidbody2D rigidbody, float speed)
        {
            _rigidbody = rigidbody;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _movementVector.Set(horizontal * Speed , vertical * Speed, 0);
            _rigidbody.velocity = _movementVector;
        }

        public void Move(Rigidbody2D rigidbody, float horizontal, float vertical, float deltaTime)
        {
            _movementVector.Set(horizontal * Speed, vertical * Speed, 0);
            rigidbody.velocity = _movementVector;
        }

    }
}
