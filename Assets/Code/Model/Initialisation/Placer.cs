using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class Placer
    {
        private IFactory<InteractiveObjectView> _factory;
        private List<Vector2> _coordinates;

        public Placer (Coordinates coordinates, IFactory<InteractiveObjectView> factory)
        {
            _coordinates = new List<Vector2>(coordinates.GetCoordinates());
            _factory = factory;
        }

        public void Spawn(List <InteractiveObjectView> views)
        {
            foreach (var coordinates in _coordinates)
            {
                var temp = _factory.GetNewObject();
                temp.Transform.position = coordinates;
                views.Add(temp);
            }
        }
    }
}
