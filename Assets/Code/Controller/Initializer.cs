using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public sealed class Initializer
    {
        public Initializer(Controllers controllers, Data data)
        {
            controllers.Add(new PlayerShipController(data.GetData<ActiveObjectData>(ObjectType.Player)));


        }
    }
}
