using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public abstract class ModificationWeapon : IFire
    {
        private BasicWeapon<ProjectileView> _weapon;

        public Transform ShootingPoint => _weapon.ShootingPoint;

        protected abstract BasicWeapon<ProjectileView> AddModification(BasicWeapon<ProjectileView> weapon);

        public void ApplyModification(BasicWeapon<ProjectileView> weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void Fire()
        {
            _weapon.Fire();
        }
    }
}
