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
        private ProgressController _progressController;

        private ActiveObjectData _enemyData;

        private int _hitPoints;
        private float _speed;
        private Transform _player;

        private Placer _placer;
        private IPool<ProjectileView> _enemyProjectilePool;

        private List<IView> _views;
        private HashSet<IBehaviour> _behaviours;
        private HashSet<ICleanup> _healths;


        private GroupHealthManager _groupHealth;


        public EnemyController(Data data, Transform player, ProgressController progressController)
        {
            _player = player;

            _enemyData = data.GetData<ActiveObjectData>(ObjectType.Enemy);
            
            _hitPoints = _enemyData.HitPoints;
            _speed = _enemyData.Speed;
            
            var _prototype = _enemyData.GetPrefab();
            _placer = new Placer(new RegularFactory<GameObject>(_prototype.gameObject));

            _views = new List<IView>();
            _behaviours = new HashSet<IBehaviour>();

            _placer.MassSpawn(_views, data.GetData<Coordinates>(ObjectType.EnemyPlacement).GetCoordinates());


            _enemyProjectilePool = new ProjectilePool<ProjectileView>(_enemyData.WeaponData.GetPrefab<ProjectileView>(), 8 );


            _groupHealth = new GroupHealthManager();
            _progressController = progressController;
            _groupHealth.DeathImplementator.OnDeath += _progressController.EnemyDied;

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


            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    RecreateFrom(Vector2.zero, (EnemyShipBehaviour)_behaviours.FirstOrDefault(), (HealthManager)_healths.FirstOrDefault());
            //}

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
            _groupHealth.Cleanup();
            _groupHealth.DeathImplementator.OnDeath -= _progressController.EnemyDied;
        }

        private void SetUpNewEnemy(IView view)
        {
            if ((view is IRigidBody rigidBodyView) && (view is ITransform transformView) && (view is IArmed armedView))
            {
                var movementManager = new MovementManager(new RigidBodyMovement(rigidBodyView.Rigidbody, _speed), new GradualRigidBodyRotation(rigidBodyView.Rigidbody, _speed));
                var weapon = new BasicWeapon<ProjectileView>(_enemyProjectilePool, armedView.WeaponTransform, _enemyData.WeaponData.WeaponStats);
                _behaviours.Add(new EnemyShipBehaviour(movementManager, new NPWeaponAttackManager (weapon, transformView.Transform, _player), view, _player));
            }


            if (view is IDamagible damagibleView)
            {
                _groupHealth.AddToTheGroup(damagibleView, _hitPoints, 1);
            }

            view.GameObject.GetComponent<ISpriteRenderer>().SpriteRenderer.color = Color.red;
        }



        
    }
}
