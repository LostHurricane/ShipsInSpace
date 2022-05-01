using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Drawing;


namespace ShipsInSpaceUI
{
    public class ColourSettingsPanel : BaseUi
    {
        private Slider _sliderRed;
        private Slider _sliderGreen;
        private Slider _sliderBlue;


        private Image _image;
        private Color _curentColor;


        public ColourSettingsPanel(GameObject panel, Slider sliderRed, Slider sliderGreen, Slider sliderBlue) : base(panel)
        {
            
            _sliderRed = sliderRed;
            _sliderGreen = sliderGreen;
            _sliderBlue = sliderBlue;

            _curentColor = Color.black;
            _image = _panel.GetComponentInChildren<Image>();
            ColorProve();
            SetDependencies();
        }

        private void SetDependencies ()
        {
            _sliderRed.onValueChanged.AddListener(RedScrollCheck);
            _sliderGreen.onValueChanged.AddListener(GreenScrollCheck);
            _sliderBlue.onValueChanged.AddListener(BlueScrollCheck);

        }


        public void RedScrollCheck(float value)
        {
            ScrollCheck(value, out var par);
            _curentColor.r = par;
            ColorProve();
        }

        public void GreenScrollCheck(float value)
        {
            ScrollCheck(value, out var par);
            _curentColor.g = par;
            ColorProve();
        }

        public void BlueScrollCheck(float value)
        {
            ScrollCheck(value, out var par);
            _curentColor.b = par;
            ColorProve();
        }

        public void ScrollCheck(float value, out float par)
        {
            par = value ;
        }

        private void ColorProve()
        {
            _image.color = _curentColor;
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
