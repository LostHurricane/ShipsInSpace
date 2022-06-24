using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class PlayerStatsManager
    {
        public Action OnDeathEvent; 

        public HealthManager HealthManager { get; private set; }

        public PlayerStatsManager (IDamagible view, int maxHp)
        {
            HealthManager = new HealthManager(view, maxHp);
            HealthManager.SetAction();
        }


    }
}
