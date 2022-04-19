using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Linq;

namespace ShipsInSpace
{
    public class EnemyController : IController, IInitialization, IExecute, IFixedExecute, ICleanup
    {
        private int _hitPoints;
        private float _speed;
        private Transform _player;

        private Placer _placer;

        private List<IView> _views;
        private HashSet<IBehaviour> _behaviours;
        private HashSet<ICleanup> _healths;





        public EnemyController(Data data, Transform player)
        {
            _hitPoints = data.GetData<ActiveObjectData>(ObjectType.Enemy).HitPoints;
            _speed = data.GetData<ActiveObjectData>(ObjectType.Enemy).Speed;
            _player = player;

            var _prototype = data.GetData<ActiveObjectData>(ObjectType.Enemy).GetPrefab().GetComponent<IView>();
            _placer = new Placer(new RegularFactory<GameObject>(_prototype.GameObject));

            _views = new List<IView>();
            _behaviours = new HashSet<IBehaviour>();
            _healths = new HashSet<ICleanup>();

            _placer.MassSpawn(_views, data.GetData<Coordinates>(ObjectType.EnemyPlacement).GetCoordinates());

        }

        public void Initialization()
        {


            foreach (var view in _views)
            {
                SetUpNewEnemy(view);

            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var behaviour in _behaviours)
            {
                if (behaviour is IUpdateBehaviour updateBehaviour)
                    updateBehaviour.Behave(deltaTime);
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                RecreateFrom(Vector2.zero, (EnemyShipBehaviour)_behaviours.FirstOrDefault(), (HealthManager)_healths.FirstOrDefault());
            }

        }

        public void FixedExecute(float deltaTime)
        {
            foreach (var behaviour in _behaviours)
            {
                if (behaviour is IFixedBehaviour fixedBehaviour)
                    fixedBehaviour.FixedBehave(deltaTime);
            }

        }

        public void Cleanup()
        {
            foreach (var healthManager in _healths)
            {
                healthManager.Cleanup();
            }
        }

        private void SetUpNewEnemy(IView view)
        {
            if (view is IRigidBody rigidBodyView)
            {
                var movementManager = new MovementManager(new RigidBodyMovement(rigidBodyView.Rigidbody, _speed), new GradualRigidBodyRotation(rigidBodyView.Rigidbody, _speed));
                _behaviours.Add(new EnemyShipBehaviour(movementManager, null, view, _player));

            }

            if (view is IDamagible damagibleView)
            {
                _healths.Add(new HealthManager(damagibleView, _hitPoints));

            }

            view.GameObject.GetComponent<ISpriteRenderer>().SpriteRenderer.color = Color.red;
        }

        private void RecreateFrom(Vector3 position, EnemyShipBehaviour behaviourPrototype, HealthManager healthManagerPrototype)
        {
            var view = _placer.SingleSpawn(position);
            EnemyShipBehaviour enemyShipBehaviour = (EnemyShipBehaviour)behaviourPrototype.Clone();
            HealthManager healthManager = (HealthManager)healthManagerPrototype.Clone();
            if (view is IRigidBody rigidBodyView)
            {
                enemyShipBehaviour.SetView(view).SetTarget(_player).SetRigidBody(rigidBodyView.Rigidbody);
            }

            if (view is IDamagible damagibleView)
            {
                healthManager.SetView(damagibleView).SetAction();
            }
            view.GameObject.GetComponent<ISpriteRenderer>().SpriteRenderer.color = Color.red;

            _views.Add(view);
            _behaviours.Add(enemyShipBehaviour);
            _healths.Add(healthManager);
        }

        
    }
}
