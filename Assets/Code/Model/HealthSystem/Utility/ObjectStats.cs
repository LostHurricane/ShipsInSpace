using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class ObjectStats
    {
        public int Health { get => _healthStat.Current; }
        public Action <IView> OnZeroHp;


        private HealthStat _healthStat;
        private float _armor;

        public ObjectStats (IView view, int maxHp, float armor = 1)
        {
            _healthStat = new HealthStat(maxHp);
            _armor = armor;
        }

        public void SetParameters(int maxHP, float armor)
        {
            _healthStat.FullReset(maxHP);
            _armor = armor;
        }

        public void TakeDamage(IDamagible damagible, int amount)
        {
            Debug.Log($"inputDamage{amount}");
            var healthChange = Mathf.Abs(amount);
            if (_armor > 1)
            {
                healthChange = (int)(amount / _armor);
                //Debug.Log($"new damage throu armor {healthChange}");
            }

            _healthStat.ChangeCurrentBy(-healthChange);

            if (_healthStat.Current<=0 && damagible.GameObject.activeSelf )
            {
                Debug.Log("Death");
                OnZeroHp.Invoke(damagible);
            }
        }



        public void Reset()
        {
            _healthStat.ResetToMax();
        }


    }
}
