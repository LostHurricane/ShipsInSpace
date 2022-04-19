using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class MovementManager : IMove, IRotation, ISetRigidBody
    {
        private readonly IMove _moveImplementation;
        private readonly IRotation _rotationImplementation;

        public float Speed => _moveImplementation.Speed;

        public MovementManager(IMove moveImplementation, IRotation rotationImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction, float deltaTime)
        {
            _rotationImplementation.Rotation(direction, deltaTime);
        }

        public void SetRigidBody(Rigidbody2D rigidbody)
        {
            if (_moveImplementation is ISetRigidBody setRigidBodyM)
            {
                setRigidBodyM.SetRigidBody(rigidbody);

            }

            if (_rotationImplementation is ISetRigidBody setRigidBodyR)
            {
                setRigidBodyR.SetRigidBody(rigidbody);
            }
        }
    }
}
