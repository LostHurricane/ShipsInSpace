using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public sealed class Initializer
    {
        public Initializer(Controllers controllers, Data data, ShipsInSpaceUI.UIView ui)
        {
            controllers.Add(new InputController(out var inputController));

            //Demonstraion of use of ServiceLocator
            //ServiceLocator.SetService(inputController);
            var progressController = new ProgressController();
            controllers.Add(progressController);
            controllers.Add(new PlayerShipController(data.GetData<ActiveObjectData>(ObjectType.Player), inputController, out var player));
            controllers.Add(new EnemyController(data, player, progressController));

            controllers.Add(new CameraController(player, new Vector3 (0,0,-10), out var currentCamera));
            controllers.Add(new UIController(ui, inputController, progressController, currentCamera));

        }
    }
}
