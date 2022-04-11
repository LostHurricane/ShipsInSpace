using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    [CreateAssetMenu (fileName = "ObjectConfig", menuName = "Configs/ObjectConfig")]
    public class ObjectData : ScriptableObject, IObjectData
    {
        [SerializeField]
        protected GameObject _prefab;

        public GameObject GetPrefab ()
        {
            if (_prefab)
                return _prefab;
            else
                throw new Exception("Prefab is empty");
        }

    }
}
