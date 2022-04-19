using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class HealthManager: ICleanup, ICloneable
    {
        private IDamagible _view; 
        private HealthStat _healthStat;
        public HealthManager(IDamagible view, int maxHp)
        {
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
            _healthStat.ChangeCurrentBy(amount);
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
