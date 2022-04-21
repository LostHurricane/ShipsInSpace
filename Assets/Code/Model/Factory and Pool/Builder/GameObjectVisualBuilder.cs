using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class GameObjectVisualBuilder : GameObjectBuilder
    {
        public GameObjectVisualBuilder(GameObject gameObject) : base(gameObject) { }

        public GameObjectVisualBuilder Name(string name)
        {
            _gameObject.name = name;
            return this;
        }

        public GameObjectVisualBuilder Sprite(int layer)
        {
            var component = GetOrAddComponent<SpriteRenderer>();
            component.sortingOrder = layer;
            return this;
        }

        public GameObjectVisualBuilder Sprite(int layer, Sprite sprite)
        {
            var component = GetOrAddComponent<SpriteRenderer>();
            component.sortingOrder = layer;
            component.sprite = sprite;
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
