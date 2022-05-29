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
        //Using Dictionary in case of searching for specific view
        private Dictionary<IDamagible, ObjectStats> _group;
        //private HashSet<ObjectStats> _objects;

        public GroupHealthManager ()
        {
            _group = new Dictionary<IDamagible, ObjectStats>();
            //_objects = new HashSet<ObjectStats>();
            DeathImplementator = new DeathImplementator();
        }

        public void AddToTheGroup(IDamagible view, int maxHp, float armour)
        {
            var stats = new ObjectStats(view, maxHp, armour);

            _group.Add(view, stats);
            DeathImplementator.Implement(stats);

        }

        public void ResetStats (IDamagible damagible, int maxHp, float armor)
        {
            //_objects.FirstOrDefault(stats => stats.View == damagible);

            if (_group.ContainsKey(damagible))
            {
                _group[damagible].SetParameters(maxHp, armor);
            }
        }

        public void Cleanup()
        {
            foreach (var stat in _group)
            {
                stat.Value.Cleanup();
            }
            DeathImplementator.Cleanup();
        }




    }



}
