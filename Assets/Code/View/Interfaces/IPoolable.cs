using System;
using UnityEngine;

namespace ShipsInSpace
{
    public interface IPoolable
    {
        Action<Transform> OnReturnToPool { get; set; }
    }
}
