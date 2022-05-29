using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class DeathImplementator : ICleanup
    {
        public Action OnDeath;
        private HashSet<ObjectStats> _stats;
        
        public DeathImplementator ()
        {
            _stats = new HashSet<ObjectStats>();
        }

        public void Implement (ObjectStats objectStats)
        {
            if (!_stats.Contains(objectStats))
            {
                _stats.Add(objectStats);
                objectStats.OnZeroHp += Death;
            }
        }

        private void Death (IView view)
        {
            view.GameObject.SetActive(false);
            if (OnDeath != null)
            {
                OnDeath.Invoke();
            }
        }

        public void Cleanup()
        {
            foreach (var stat in _stats)
            {
                stat.OnZeroHp -= Death;
            }
        }
    }
}
