using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class GameObjectPhysicsBuilder : GameObjectBuilder
    {
        public GameObjectPhysicsBuilder(GameObject gameObject) : base(gameObject) { }

        public GameObjectPhysicsBuilder BoxCollider2D(float xSize = 1, float ySize = 1, bool trigger = false)
        {
            var component = GetOrAddComponent<BoxCollider2D>();
            component.size = new Vector2(xSize, ySize);
            component.isTrigger = trigger;
            return this;
        }

        public GameObjectPhysicsBuilder Rigidbody2D(float mass = 1, float gravity = 1)
        {
            var component = GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            component.gravityScale = gravity;
 

            return this;
        }

        private T GetOrAddComponent<T>() where T : Component
        {
            var result = _gameObject.GetComponent<T>();
            if (!result)
            {
                result = _gameObject.AddComponent<T>();
            }
            return result;
        }

    }
}
