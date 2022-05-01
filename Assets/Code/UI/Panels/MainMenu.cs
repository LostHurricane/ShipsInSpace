using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShipsInSpaceUI
{
    public class MainMenu : BaseUi
    {
        private Button _buttonToSettings;
        public Button ButtonToSettings { get => _buttonToSettings; set => _buttonToSettings = value; }

        private Button _buttonToTimeSettings;
        public Button ButtonToTimeSettings { get => _buttonToTimeSettings; }


        public MainMenu(GameObject g, Button settingsButton, Button timescaleButton) : base (g)
        {
            _buttonToSettings = settingsButton;
            _buttonToTimeSettings = timescaleButton;
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
