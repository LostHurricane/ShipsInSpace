using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class EnemyController : IController, IInitialization, IExecute, IFixedExecute
    {
        private float _speed;
        private Transform _player;

        private Placer _placer;
        private List<InteractiveObjectView> _enemysView;
        private Dictionary <InteractiveObjectView, MovementManager> _enemysViews;


        public EnemyController(Data data, Transform player)
        {
            var _prototype = data.GetData<ActiveObjectData>(ObjectType.Enemy).GetPrefab().GetComponent<InteractiveObjectView>();

            _player = player;
            _placer = new Placer(data.GetData<Coordinates>(ObjectType.EnemyPlacement), new RegularFactory<InteractiveObjectView>(_prototype));
            _enemysViews = new Dictionary<InteractiveObjectView, MovementManager>();
            _speed = data.GetData<ActiveObjectData>(ObjectType.Enemy).Speed;
        }

        public void Initialization()
        {
            List<InteractiveObjectView> views = new List<InteractiveObjectView>();
            _placer.Spawn(views);
            foreach (var e in views)
            {
                _enemysViews.Add(e, new MovementManager(new RigidBodyMovement(e.Rigidbody, _speed), new GradualRigidBodyRotation(e.Rigidbody, _speed / 3)));
                e.SpriteRenderer.color = Color.red;
            }
        }

        public void Execute(float deltaTime)
        {
            //throw new System.NotImplementedException();
        }

        public void FixedExecute(float deltaTime)
        {
            foreach (var e in _enemysViews)
            {
                var _direction = _player.position - e.Key.Transform.position;
                e.Value.Move(e.Key.Transform.up.x, e.Key.Transform.up.y, deltaTime);
                e.Value.Rotation(_direction, deltaTime);


            }
        }

        
    }
}
