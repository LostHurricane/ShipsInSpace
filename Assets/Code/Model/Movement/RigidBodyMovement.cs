using UnityEngine;

namespace ShipsInSpace
{
    public class RigidBodyMovement : IMove, ISetRigidBody
    {
        public float Speed { get; protected set; }

        private Rigidbody2D _rigidBody;
        private Vector3 _movementVector;

        public RigidBodyMovement (Rigidbody2D rigidbody, float speed)
        {
            _rigidBody = rigidbody;
            Speed = speed;
        }


        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _movementVector.Set(horizontal * Speed , vertical * Speed, 0);
            _rigidBody.velocity = _movementVector;
        }

        public void Move(Rigidbody2D rigidbody, float horizontal, float vertical, float deltaTime)
        {
            _movementVector.Set(horizontal * Speed, vertical * Speed, 0);
            rigidbody.velocity = _movementVector;
        }

        public void SetRigidBody(Rigidbody2D rigidbody)
        {
            _rigidBody = rigidbody;
        }

    }
}
