using System;
using UnityEngine;

namespace ShipsInSpace
{
    public interface IPoolable : IView
    {
        Action<Transform> OnReturnToPool { get; set; }

        void ReturnToPool();
    }
}
