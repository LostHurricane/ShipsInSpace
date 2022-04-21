using UnityEngine;

namespace ShipsInSpace
{
    public interface ICollider: IView
    {
        Collider2D Collider { get; }
    }
}
