using UnityEngine;

namespace ShipsInSpace
{
    public interface IWeapon 
    {
        Transform ShootingPoint { get; }
    }
}
