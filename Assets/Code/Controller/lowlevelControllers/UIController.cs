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

        public UIController (UIView prefab, InputController inputController, ProgressController progressController, Camera camera )
        {
            _uIView = prefab;
            //_uIView = new RegularFactory<UIView>(prefab).GetNewObject();
            _uIView.Canvas.worldCamera = camera;
            _progressController = progressController;

            _pointsIndicator = _uIView.GetUIElement(UIElementType.POINTS_INDICATOR).GetComponent<TextMeshProUGUI>();
  
        }


        public void Execute(float deltaTime)
        {
            //Debug.Log(_progressController.points);
            _pointsIndicator.text = _progressController.points.ToString();
        }

        
    }
}
