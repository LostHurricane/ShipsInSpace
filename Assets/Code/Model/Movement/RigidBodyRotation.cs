using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class RigidBodyRotation : IRotation
    {

        private Rigidbody2D _rigidBody;

        private float _angle;

        public RigidBodyRotation(Rigidbody2D rigidbody)
        {
            _rigidBody = rigidbody;
        }

        public void Rotation(Vector3 direction, float deltaTime)
        {
            _angle = -(Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg);

            Debug.Log(_angle);
            _rigidBody.SetRotation(Quaternion.AngleAxis(_angle, Vector3.forward));
        }

        
    }
}
