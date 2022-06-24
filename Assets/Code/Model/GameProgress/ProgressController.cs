using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class ProgressController: IController
    {
        private const int POINTS_FOR_ENEMYSHIP = 550;

        private int _points;
        public int points => _points;

        public ProgressController ()
        {
            
            _points = 0;
        }

        public void SetPoints(int points)
        {
            _points = points;
        }

        public void EnemyDied ()
        {
            Debug.Log( "Enemy died");
            _points += POINTS_FOR_ENEMYSHIP;
        }


    }
}
