using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public sealed class Initializer
    {
        private Transform _player;
        public Initializer(Controllers controllers, Data data)
        {
            controllers.Add(new PlayerShipController(data.GetData<ActiveObjectData>(ObjectType.Player), out _player));
            controllers.Add(new EnemyController(data, _player));


        }
    }
}
