using System;
using UnityEngine;

namespace ShipsInSpace
{
    public class EnemyShipBehaviour : IBehaviour, IFixedBehaviour, ICloneable, IUpdateBehaviour
    {
        public bool IsActive { get => _view.GameObject.activeSelf; }

        private IView _view;
                
        private IMovementManager _movementImplementation;
        private IAttack _attackImplementation;
        

        private Transform _target;

        public EnemyShipBehaviour(IMovementManager movementManager, IAttack weapon, IView view, Transform transformTarget)
        {
            _movementImplementation = movementManager;
            _attackImplementation = weapon;
            _view = view;
            _target = transformTarget;
        }

        public void Behave(float deltaTime)
        {
            _attackImplementation.Attack(deltaTime);
        }

        public void FixedBehave(float deltaTime)
        {
            if (_view.GameObject.activeSelf)
            {
                if (_view is ITransform iTransform)
                {
                    var _direction = _target.position - iTransform.Transform.position;

                    if(_movementImplementation is IMove mover)
                    {
                        mover.Move(iTransform.Transform.up.x, iTransform.Transform.up.y, deltaTime);
                    }

                    if (_movementImplementation is IRotation rotation)
                    {
                        rotation.Rotation(_direction, deltaTime);
                    }

                }
            }
        }

        public object Clone()
        {
            IMovementManager movementManager;

            if (_movementImplementation is IMove mover)
            {
                movementManager = new MovementManager(new RigidBodyMovement(null, mover.Speed), new GradualRigidBodyRotation(null, mover.Speed / 4));

            }
            else
                throw new Exception ();
            return new EnemyShipBehaviour(movementManager,null,null,null);
        }

        #region Builder

        public EnemyShipBehaviour SetView(IView view)
        {
            _view = view;
            return this;
        }

        public EnemyShipBehaviour SetMovementManager(MovementManager movementManager)
        {
            _movementImplementation = movementManager;
            return this;
        
        }

        public EnemyShipBehaviour SetTarget(Transform transform)
        {
            _target = transform;
            return this;
        }

        public EnemyShipBehaviour SetRigidBody(Rigidbody2D rigidbody)
        {
            if (_movementImplementation is ISetRigidBody rb)
            {
                rb.SetRigidBody(rigidbody);
            }
            return this;
        }

       


        #endregion


    }
}
