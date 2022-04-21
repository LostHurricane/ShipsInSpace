using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class PlayerShipController : IController, IInitialization , IExecute, IFixedExecute
    {
        private InputController _inputController;

        private InteractiveObjectView _player;
        private MovementManager _movementManager;
        private IWeapon _weapon;

        private Camera _camera;

        private Vector3 _direction;

        public PlayerShipController(ActiveObjectData playerData, InputController inputController ,out Transform player)
        {
            _inputController = inputController;

            _player = Object.Instantiate(playerData.GetPrefab()).GetComponent<InteractiveObjectView>();
            _movementManager = new MovementManager(new RigidBodyMovement(_player.Rigidbody, playerData.Speed), new RigidBodyRotation(_player.Rigidbody));
            _weapon = new BasicWeapon<ProjectileView>(new ProjectilePool<ProjectileView>(playerData.WeaponData.GetPrefab().GetComponent<ProjectileView>(),5),_player.Transform.Find("WeaponPosition"), playerData.WeaponData.WeaponStats);
            player = _player.Transform;
        }

        public void Initialization()
        {
            _camera = Camera.current;

        }

        public void Execute(float deltaTime)
        {
            _direction = _inputController.MousePosition - _camera.WorldToScreenPoint(_player.Transform.position);
            
            //Test if service locator is working
            //if (ServiceLocator.Resolve<InputController>().Fire) 

            if (_inputController.Fire)
            {
                _weapon.Fire();
            }

        }

        public void FixedExecute(float deltaTime)
        {

            _movementManager.Move(_inputController.AxisHorizontal, _inputController.AxisVertical, deltaTime);
            _movementManager.Rotation(_direction, deltaTime);
        }

        
    }
}
