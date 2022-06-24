using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class ProjectileColourChanger : ModificationWeapon
    {
        private Color _color;

        public ProjectileColourChanger(Color color)
        {
            _color = color;
        }


        protected override BasicWeapon<ProjectileView> AddModification(BasicWeapon<ProjectileView> weapon)
        {
            weapon.ChangeAmmunitionColour(_color);
            return weapon;
        }

    }
}
