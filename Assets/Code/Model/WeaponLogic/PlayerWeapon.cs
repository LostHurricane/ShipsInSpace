using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class PlayerWeapon : IWeapon, IReload
    {
        public int _volume { get; protected set; }
        public int _damage { get; protected set; }

        private IPool<InteractiveObjectView> _projectilePool;

        public PlayerWeapon (IPool<InteractiveObjectView> pool, WeaponStats weaponStats)
        {
            _projectilePool = pool;
            _volume = weaponStats.Volume;
            _damage = weaponStats.Damage;

        }

        public void Fire()
        {
            
        }

        IEnumerator IReload.Reload()
        {
            throw new System.NotImplementedException();
        }

        private InteractiveObjectView SetUpBullet()
        {
            throw new Exception();
        }
    }
}
