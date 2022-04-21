using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class HealthStat 
    {
        public int Max { get; private set; }
        public int Current { get; private set; }

        public HealthStat(int max)
        {
            Max = max;
            Current = max;
        }

        /// <summary>
        /// When starting Health is not Max
        /// </summary>
        /// <param name="max"></param>
        /// <param name="current"></param>
        public HealthStat(int max, int current)
        {
            Max = max;
            Current = current;
        }

        public void ChangeCurrent(int hp)
        {
            Current = hp;
        }

        public void ChangeCurrentBy(int amount)
        {
            //Debug.Log("current health health" + Current);

            Current += amount;

            //Debug.Log("current health after health" + Current);

        }

        public void ResetToMax()
        {
            Current = Max;
        }

        public void FullReset(int maxHp)
        {
            Max = maxHp;
            ResetToMax();
        }
    }
}
