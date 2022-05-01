using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Drawing;


namespace ShipsInSpaceUI
{
    public class TimeSetingsPanel : BaseUi
    {
        private Slider _slider;
        private Text _text;
        


        public TimeSetingsPanel(GameObject panel, Slider slider) : base(panel)
        {

            _slider = slider;
            _text = _panel.GetComponentInChildren<Text>();
            SetDependencies();
        }

        private void SetDependencies ()
        {
            _slider.onValueChanged.AddListener(ScrollCheck);
        }


        public void ScrollCheck(float value)
        {
            var newValue = value * 3;
            _text.text = newValue.ToString();

            Time.timeScale = newValue;

        }

        public override void Cancel()
        {
            _panel.SetActive(false);
        }

        public override void Execute()
        {
            _panel.SetActive(true);
        }
    }
}
