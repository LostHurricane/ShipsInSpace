using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

namespace ShipsInSpaceUI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private Canvas _canvas;
        public Canvas Canvas { get; set; }

        [SerializeField]
        private List<PanelProperty> panelProperties;

        private MainMenu mainMenu;
        private ColourSettingsPanel colourSettings;
        private TimeSetingsPanel timeSetings;



        private readonly Stack<StateUI> _stateUi = new Stack<StateUI>();
        private BaseUi _currentWindow;

        private void Start()
        {
            var property = panelProperties.FirstOrDefault(panel => panel.Window == StateUI.MainMenu);
            mainMenu = new MainMenu(property.GameObject, property.Components[0].GetComponent<Button>(), property.Components[1].GetComponent<Button>());
            mainMenu.Cancel();

            property = panelProperties.FirstOrDefault(panel => panel.Window == StateUI.PanelColourSettings);
            colourSettings = new ColourSettingsPanel(property.GameObject, property.Components[0].GetComponent<Slider>(), 
                property.Components[1].GetComponent<Slider>(), property.Components[2].GetComponent<Slider>());
            colourSettings.Cancel();

            property = panelProperties.FirstOrDefault(panel => panel.Window == StateUI.PanelTimeSettings);
            timeSetings = new TimeSetingsPanel(property.GameObject, property.Components[0].GetComponent<Slider>());
            timeSetings.Cancel();

            mainMenu.ButtonToSettings.onClick.AddListener(OpenColourSettings);
            mainMenu.ButtonToTimeSettings.onClick.AddListener(OpenTimeSettings);
        }

        private void Execute(StateUI stateUI, bool isSave = true)
        {
            if (_currentWindow != null)
            {
                _currentWindow.Cancel();
            }
            switch (stateUI)
            {
                case StateUI.MainMenu:
                    _currentWindow = mainMenu;
                    break;
                case StateUI.PanelColourSettings:
                    _currentWindow = colourSettings;
                    break;
                case StateUI.PanelTimeSettings:
                    _currentWindow = timeSetings;
                    break;
                default:
                    return;
                    //break;
            }
            _currentWindow.Execute();
            if (isSave)
            {
                _stateUi.Push(stateUI);
            }
        }

        private void CloseCurrent ()
        {
            if (_currentWindow != null)
            {
                _currentWindow.Cancel();
                _currentWindow = null;
            }
        }

        private void OpenColourSettings()
        {
            Execute(StateUI.PanelColourSettings);
        }

        private void OpenTimeSettings()
        {
            Execute(StateUI.PanelTimeSettings);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (_currentWindow != null)
                {
                    CloseCurrent();
                }
                else
                {
                    Execute(StateUI.MainMenu);
                }

            }
        }

        private void LateUpdate()
        {
            if (_canvas.worldCamera == null) 
            {
                _canvas.worldCamera = Camera.current;
            }
        }

    }
}
