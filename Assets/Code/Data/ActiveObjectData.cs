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
        public float Speed => _speed;

        [SerializeField]
        private int _hitPoints;
        public int HitPoints
        {
            get => _hitPoints;
        }

        [SerializeField]
        private bool IsArmed;

        [SerializeField]
        private WeaponData _weaponData;

        public WeaponData WeaponData
        {
            get
            {
                if (IsArmed)
                {
                    return _weaponData;
                }
                else
                {
                    return null;
                }
            }
        }


    }
}
