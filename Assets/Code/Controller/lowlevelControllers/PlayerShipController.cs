using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class PlayerShipController : IController, IExecute, IFixedExecute
    {
        private InteractiveObjectView _player;
        private MovementManager _movementManager;

        private Camera _camera;

        private Vector3 _direction;

        public PlayerShipController(ActiveObjectData playerData)
        {
            _camera = Camera.main;
            _player = Object.Instantiate(playerData.GetPrefab()).GetComponent<InteractiveObjectView>();
            _movementManager = new MovementManager(new RigidBodyMovement(_player.Rigidbody, playerData.Speed), new RigidBodyRotation(_player.Rigidbody));
        }

        public void Execute(float deltaTime)
        {
            _direction = Input.mousePosition - _camera.WorldToScreenPoint(_player.Transform.position);

        }

        public void FixedExecute(float deltaTime)
        {

            _movementManager.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), deltaTime);
            _movementManager.Rotation(_direction, deltaTime);
        }
    }
}
