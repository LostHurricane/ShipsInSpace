using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class WeaponDamageModifier : ActiveObjectModifier
    {
        private IChangeDamage _weapon;
        private int _amount;


        public WeaponDamageModifier (IChangeDamage weapon, int armor)
        {
            _weapon = weapon;
            _amount = armor;
        }

        public override void Handle()
        {
            _weapon.ChangeDamage(_amount);
            base.Handle();
        }

    }
}
