using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class ArmorModifier : ActiveObjectModifier
    {
        private HealthManager _healthManager;
        private int _armor;

        public ArmorModifier (HealthManager healthManager, int armor)
        {
            _healthManager = healthManager;
            _armor = armor;
        }

        public override void Handle()
        {
            _healthManager.ArmorFactor = _armor;
            base.Handle();
        }
    }
}
