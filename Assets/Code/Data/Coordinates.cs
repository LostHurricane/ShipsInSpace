using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    [CreateAssetMenu(fileName = "CoordinatesSet", menuName = "Configs/CoordinatesSet", order = 4)]
    public class Coordinates : ScriptableObject
    {
        [SerializeField]
        private List<Vector2> _coordinates;

        public Vector2[] GetCoordinates()
        {
            return _coordinates.ToArray();
        }
    }
}
