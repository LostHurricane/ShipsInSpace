using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class BasicWeapon <T> : IFire, IChangeDamage where T: ITransform, IRigidBody, IDamageDealer
    {

        public int Damage { get; protected set; }
        public Transform ShootingPoint { get; protected set; }
        public float ShootingForce { get; protected set; }

        private Color _ammunitionColor = Color.green;
        private IPool<T> _projectilePool;

        public BasicWeapon (IPool<T> pool, Transform shootingPoint, WeaponStats weaponStats)
        {
            _projectilePool = pool;
            ShootingForce = weaponStats.PushForce;
            ShootingPoint = shootingPoint;
            Damage = weaponStats.Damage;
        }

        public void Fire()
        {
            SetUpBullet().Rigidbody.AddForce(ShootingPoint.up * ShootingForce, ForceMode2D.Impulse);
        }

        public void ChangeAmmunitionColour(Color color)
        {
            _ammunitionColor = color;
        }
        private T SetUpBullet()
        {
            var temp = _projectilePool.GetNewObject();

            if (temp is IDamageDealer)
            {
                temp.OnDealingDamage += DealDamage;
            }

            if (_ammunitionColor != null && temp is ISpriteRenderer renderer)
            {
                renderer.SpriteRenderer.color = _ammunitionColor;
            }

            temp.GameObject.SetActive(true);
            temp.Transform.SetParent(ShootingPoint);
            temp.Transform.localPosition = Vector3.zero;
            temp.Transform.localRotation = Quaternion.identity;
            return temp;
        }

        public void ChangeDamage(int damage)
        {
            Damage += damage;
            Debug.Log("damage changed to" + Damage);
        }

        private void DealDamage (IDamagible target)
        {
            target.TakeDamage(Damage);
        } 
    }
}
