using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "Configs/WeaponConfig")]
    public class WeaponData : ScriptableObject
    {
        public WeaponStats WeaponStats;
    }
}
