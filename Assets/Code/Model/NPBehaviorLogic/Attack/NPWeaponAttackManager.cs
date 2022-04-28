using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipsInSpace
{
    public class NPWeaponAttackManager : IAttack
    {
        private const float AIM_THRESHHOLD = 5f;

        private IFire _weaponInplementation;
        private Transform _weaponPoint;
        private Transform _target;

        private float _currentTime;
        private float _coolDown = 0.5f;
        private bool _readyToShoot;

        public NPWeaponAttackManager (IFire weapon, Transform view, Transform target)
        {
            _weaponPoint = view;
            _target = target;
            _weaponInplementation = weapon;


            if (weapon is BasicWeapon<ProjectileView> modifiable)
            {
                ModificationWeapon modifier = new ProjectileColourChanger(Color.cyan);
                modifier.ApplyModification(modifiable);
                _weaponInplementation = modifier;

            }
            else
            {
                _weaponInplementation = weapon;
            }

            

        }

        public void Attack(float deltaTime)
        {
            if (ConditionsCheck(_target))
            {
                if (_readyToShoot)
                {
                    WeaponAttack();
                    _readyToShoot = false;
                }

                //Debug.Log("attack");
            }
            Timeout(deltaTime);

        }

        public void WeaponAttack ()
        {
            _weaponInplementation.Fire();
        }

        public void Timeout(float deltatime)
        {
            if (_readyToShoot)
            {
                return;
            }

            if (_currentTime >= _coolDown)
            {
                _currentTime = 0f;
                _readyToShoot = true;

            }
            else
            {
                _currentTime += deltatime;

            }

        }

        private bool ConditionsCheck(Transform targetTransform)
        {
            var angle = Vector3.Angle(_weaponPoint.up, targetTransform.position - _weaponPoint.position);
            //Debug.Log("angle " + angle);

            return angle < AIM_THRESHHOLD ? true : false;
        }

    }
}
