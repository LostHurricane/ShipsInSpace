using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public interface IArmed: IView
    {
        Transform WeaponTransform { get; }
    }
}
