using UnityEngine;

namespace ShipsInSpace
{
    public interface IRigidBody: IView
    {
        Rigidbody2D Rigidbody { get; }

    }
}
