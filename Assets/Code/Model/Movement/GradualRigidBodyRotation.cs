using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class GradualRigidBodyRotation : IRotation
    {
        private Rigidbody2D _rigidBody;

        private float _angle;
        private float _rotationSpeed;

        public GradualRigidBodyRotation (Rigidbody2D rigidbody, float rotationSpeed)
        {
            _rigidBody = rigidbody;
            _rotationSpeed = rotationSpeed;
        }

        public void Rotation(Vector3 direction, float deltaTime)
        {

            Vector3 newDirection = Vector3.RotateTowards(_rigidBody.transform.up, direction, _rotationSpeed * deltaTime, 0f);
            _angle = -(Mathf.Atan2(newDirection.x, newDirection.y) * Mathf.Rad2Deg);
            _rigidBody.SetRotation(Quaternion.AngleAxis(_angle, Vector3.forward));


        }

       
    }
}
