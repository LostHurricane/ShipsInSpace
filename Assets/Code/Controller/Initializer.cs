using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public sealed class Initializer
    {
        public Initializer(Controllers controllers, Data data)
        {
            controllers.Add(new InputController(out var inputController));

            //Demonstraion of use of ServiceLocator
            //ServiceLocator.SetService(inputController); 

            controllers.Add(new PlayerShipController(data.GetData<ActiveObjectData>(ObjectType.Player), inputController, out var player));
            controllers.Add(new EnemyController(data, player));

            controllers.Add(new CameraController(player, new Vector3 (0,0,-10), out var currentCamera));
        }
    }
}
