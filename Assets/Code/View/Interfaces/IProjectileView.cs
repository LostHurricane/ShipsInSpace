using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public interface IProjectileView : ITransform, IRigidBody, ICollider, IDamageDealer, IPoolable, ISpriteRenderer
    {


    }
}
