using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class RegularFactory <T> : IFactory <T> where T: MonoBehaviour//Object
    {
        private T _example;

        public RegularFactory (T example)
        {
            _example = example;
        }

        public T GetNewObject()
        {
            var temp = Object.Instantiate(_example);
            return temp;
        }

        
    }
}
