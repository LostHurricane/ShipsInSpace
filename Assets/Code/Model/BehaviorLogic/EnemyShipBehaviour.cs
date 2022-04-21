using System;
using UnityEngine;

namespace ShipsInSpace
{
    public class EnemyShipBehaviour : IBehaviour, IFixedBehaviour, ICloneable//, IUpdateBehaviour
    {
        public bool IsActive { get => _view.GameObject.activeSelf; }

        private IView _view;

        
        private MovementManager _movementManager;
        private IWeapon _weapon;
        

        private Transform _target;

        public EnemyShipBehaviour(MovementManager movementManager, IWeapon weapon, IView view, Transform transformTarget)
        {
            _movementManager = movementManager;
            _weapon = weapon;
            _view = view;
            _target = transformTarget;
        }

        public void FixedBehave(float deltaTime)
        {
            if (_view.GameObject.activeSelf)
            {
                if (_view is ITransform iTransform)
                {
                    var _direction = _target.position - iTransform.Transform.position;


                    _movementManager.Move(iTransform.Transform.up.x, iTransform.Transform.up.y, deltaTime);
                    _movementManager.Rotation(_direction, deltaTime);
                }
            }
        }

        public object Clone()
        {
            var movementManager = new MovementManager(new RigidBodyMovement(null, _movementManager.Speed), new GradualRigidBodyRotation(null, _movementManager.Speed/2));

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
            _movementManager = movementManager;
            return this;
        
        }

        public EnemyShipBehaviour SetTarget(Transform transform)
        {
            _target = transform;
            return this;
        }

        public EnemyShipBehaviour SetRigidBody(Rigidbody2D rigidbody)
        {
            _movementManager.SetRigidBody(rigidbody);
            return this;
        }

       
        #endregion


    }
}
