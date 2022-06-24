using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShipsInSpaceUI;
using TMPro;


namespace ShipsInSpace
{
    public class UIController : IController, IExecute
    {
        private UIView _uIView;
        private ProgressController _progressController;

        private TextMeshProUGUI _pointsIndicator;

        public UIController (Data data, InputController inputController, ProgressController progressController, Camera camera )
        {
            var prefab = data.GetData<ObjectData>(ObjectType.UI).GetPrefab<UIView>();
            _uIView = new RegularFactory<UIView>(prefab).GetNewObject();
            _uIView.Canvas.worldCamera = camera;
            _progressController = progressController;

            _pointsIndicator = _uIView.GetUIElement(UIElementType.POINTS_INDICATOR).GetComponent<TextMeshProUGUI>();
  
        }


        public void Execute(float deltaTime)
        {
            //Debug.Log(_progressController.points);
            
            _pointsIndicator.text = PointsInterpreter.Interpret(_progressController.points);
        }

        
    }
}
