using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public interface IDamageDealer
    {
        Action<IDamagible> OnDealingDamage { get; set; }
    }
}
