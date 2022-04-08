using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    [CreateAssetMenu(fileName = "ActiveObjectConfig", menuName = "Configs/ActiveObjectConfig")]
    public class ActiveObjectData : ObjectData
    {
        [SerializeField]
        private float _speed;
        public float Speed
        {
            get => _speed;
        }



    }
}
