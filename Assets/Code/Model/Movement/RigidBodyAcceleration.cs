using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class RigidBodyAcceleration : RigidBodyMovement, IAcceleration
    {     
        private float _basicSpeed;
        private float _maxSpeed;
        private float _accselerationFactor;
        private float _breakingFactor;

        public RigidBodyAcceleration(Rigidbody2D rigidbody, float speed, float accselerationFactor = 0.5f) : base(rigidbody, speed)
        {
            _basicSpeed = speed;
            _accselerationFactor = accselerationFactor;
            _breakingFactor = _maxSpeed / 50;
        }

        public RigidBodyAcceleration(Rigidbody2D rigidbody, float speed, float accselerationFactor, float maxSpeed) : this(rigidbody, speed, accselerationFactor)
        {
            _maxSpeed = maxSpeed;
        }

        public void Accelerate()
        {
            if (Speed < _maxSpeed)
            {
                Speed += _accselerationFactor;
            }
        }

        public void Brake()
        {
            if (Speed > _basicSpeed)
            {
                Speed -= _breakingFactor;
            }
        }
    }
}
