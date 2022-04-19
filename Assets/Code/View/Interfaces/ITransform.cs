using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public interface ITransform: IView
    {
        Transform Transform { get; }
    }
}
