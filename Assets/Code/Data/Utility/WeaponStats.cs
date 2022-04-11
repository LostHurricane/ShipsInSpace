using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    [Serializable]
    public struct WeaponStats
    {
        public int Damage;

        public bool Realodable;
        public int Volume;

        public float PushForce;
    }
}
