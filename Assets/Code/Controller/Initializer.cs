using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public sealed class Initializer
    {
        public Initializer(Controllers controllers, InteractiveObjectView view)
        {
            controllers.Add(new PlayerShipController(view));


        }
    }
}
