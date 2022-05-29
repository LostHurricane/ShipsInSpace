using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class HealthManager: ICleanup, ICloneable
    {
        public int Health { get => _healthStat.Current; }

        private float _armorFactor;
        public float ArmorFactor 
        {
            get => ArmorFactor;
            set
            {
                if (value < 0.1f)
                {
                    _armorFactor = 0.33f;
                }
                else if (value > 3f)
                {
                    _armorFactor = 3f;
                }
                else
                {
                    _armorFactor = value;
                }
            }
        }

        private IDamagible _view; 
        private HealthStat _healthStat;

        public HealthManager(IDamagible view, int maxHp)
        {
            ArmorFactor = 1;
            SetView(view).SetAction();
            _healthStat = new HealthStat(maxHp);
        }

        public HealthManager(IDamagible view, int maxHp, float armorFactor)
        {
            ArmorFactor = armorFactor;
            SetView(view).SetAction();
            _healthStat = new HealthStat(maxHp);
        }

        public void Reset()
        {
            _healthStat.ResetToMax();
        }

        public HealthManager SetView(IDamagible view)
        {
            if (view != null)
                _view = view;
            return this;
        }

        public HealthManager SetAction()
        {
            if (_view != null)
                _view.OnDamageTaken += TakeDamage;
            return this;
        }

        private void TakeDamage (int damage)
        {
            ChangeHealth(-damage);
            if (_healthStat.Current <= 0)
            {
                _view.GameObject.SetActive(false);
            }
        }

        private void ChangeHealth(int amount)
        {
            Debug.Log($"inputDamage{amount}");
            var healthChange = amount;
            if (amount < 0)
            {
                healthChange = (int)(amount / _armorFactor);
                //Debug.Log($"new damage throu armor {healthChange}");
            }

            _healthStat.ChangeCurrentBy(healthChange);

        }

        public void Cleanup()
        {
            _view.OnDamageTaken -= TakeDamage;

        }

        public object Clone()
        {
            this.GetType();
            return new HealthManager(null, _healthStat.Max);
        }
    }
}
