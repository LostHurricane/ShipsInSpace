using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class Placer
    {
        private IFactory<GameObject> _factory;

        public Placer (IFactory<GameObject> factory)
        {
            _factory = factory;

        }

        public void MassSpawn <T> (List <T> views, Vector2[] coordinates)
        {
            foreach (var position in coordinates)
            {
                var temp = _factory.GetNewObject();
                temp.transform.position = position;
                views.Add(temp.GetComponent<T>());
            }
        }

        public IView SingleSpawn(Vector2 position)
        {
            var temp = _factory.GetNewObject();
            temp.transform.position = position;
            return temp.GetComponent<IView>();
        }
    }
}
