using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class GameObjectBuilder
    {
        protected GameObject _gameObject;

        public GameObjectBuilder() => _gameObject = new GameObject();
        protected GameObjectBuilder(GameObject gameObject) => _gameObject = gameObject;

        public GameObjectVisualBuilder Visual => new GameObjectVisualBuilder(_gameObject);
        public GameObjectPhysicsBuilder Physics => new GameObjectPhysicsBuilder(_gameObject);

        public GameObjectBuilder SetPosition(Vector3 position)
        {
            _gameObject.transform.position = position;
            return this;
            
        }

        public static implicit operator GameObject(GameObjectBuilder builder)
        {
            return builder._gameObject;
        }


    }
}
