using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ShipsInSpace
{
    public class GroupHealthManager : ICleanup
    {
        public DeathImplementator DeathImplementator;
        
        private Dictionary<IDamagible, ObjectStats> _group;


        public GroupHealthManager ()
        {
            _group = new Dictionary<IDamagible, ObjectStats>();

            DeathImplementator = new DeathImplementator();
        }

        public void AddToTheGroup(IDamagible view, int maxHp, float armour)
        {
            var stats = new ObjectStats(view, maxHp, armour);

            _group.Add(view, stats);
            DeathImplementator.Implement(stats);
            view.OnDamageTaken += stats.TakeDamage;

        }

        public void ResetStats (IDamagible damagible, int maxHp, float armor)
        {


            if (_group.ContainsKey(damagible))
            {
                _group[damagible].SetParameters(maxHp, armor);
            }
        }

        public void Cleanup()
        {
            foreach (var pair in _group)
            {
                pair.Key.OnDamageTaken -= pair.Value.TakeDamage;
            }
            DeathImplementator.Cleanup();
        }




    }



}
