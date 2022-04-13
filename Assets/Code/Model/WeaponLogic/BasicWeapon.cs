using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class BasicWeapon <T> : IWeapon where T: MonoBehaviour, ITransform, IRigidBody, IDamageDealer
    {
        protected int _damage { get; set; }
        protected float _shootingForce { get; set; }
        protected Transform _shootingPoint { get; set; }

        private IPool<T> _projectilePool;

        public BasicWeapon (IPool<T> pool, Transform shootingPoint, WeaponStats weaponStats)
        {
            _projectilePool = pool;
            _shootingForce = weaponStats.PushForce;
            _shootingPoint = shootingPoint;
            _damage = weaponStats.Damage;
        }

        public void Fire()
        {
            SetUpBullet().Rigidbody.AddForce(_shootingPoint.up * _shootingForce, ForceMode2D.Impulse);
         
        }


        private T SetUpBullet()
        {
            var temp = _projectilePool.GetNewObject();

            if (temp is IDamageDealer)
            {
                temp.OnDealingDamage += DealDamage;
            }

            temp.gameObject.SetActive(true);
            temp.Transform.SetParent(_shootingPoint);
            temp.Transform.localPosition = Vector3.zero;
            temp.Transform.localRotation = Quaternion.identity;
            return temp;
        }

        private void DealDamage (IDamagible target)
        {
            target.TakeDamage(_damage);
        }

        
    }
}
