using ShipsInSpaceInput;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class InputController : IInitialization, IExecute, ICleanup, ShipsInSpaceSV.IService
    {
        private HashSet<IInput> _inputs;

        private InputCursorPosition _inputCursorPosition = new InputCursorPosition();
        private InputAxis _vertical = new InputAxis(InputNameBase.Vertical);
        private InputAxis _horizontal = new InputAxis(InputNameBase.Horizontal);
        private InputButtonPressed _fire = new InputButtonPressed(InputNameBase.Fire);

        public Vector3 MousePosition { get; private set; }
        public float AxisHorizontal { get; private set; }
        public float AxisVertical { get; private set; }
        public bool Fire { get; private set; }

        public void UpdateCursorPosition(Vector3 value) => MousePosition = value;
        public void UpdateHorizontal(float value) => AxisHorizontal = value;
        public void UpdateVertical(float value) => AxisVertical = value;
        public void UpdateFireButton(bool value) => Fire = value;

        public InputController(out InputController inputController)
        {
            inputController = this;
        }

        public void Initialization()
        {
            _inputs = new HashSet<IInput>();


            //var inputCursorPosition = new InputCursorPosition();
            _inputCursorPosition.InputOnChange += UpdateCursorPosition;
            _inputs.Add(_inputCursorPosition);

            //var vertical = new InputAxis("Vertical");
            _vertical.InputOnChange += UpdateVertical;
            _inputs.Add(_vertical);

            //var horizontal = new InputAxis("Horizontal");
            _horizontal.InputOnChange += UpdateHorizontal;
            _inputs.Add(_horizontal);

            //var fire = new InputButtonPressed("Fire1");
            _fire.InputOnChange += UpdateFireButton;
            _inputs.Add(_fire);

        }

        public void Execute(float deltaTime)
        {
            foreach (var input in _inputs)
            {
                input.GetInput();
            }
        }

        public void Cleanup()
        {
            _inputCursorPosition.InputOnChange -= UpdateCursorPosition;
            _vertical.InputOnChange -= UpdateVertical;
            _horizontal.InputOnChange -= UpdateHorizontal;
            _fire.InputOnChange -= UpdateFireButton;



        }



    }
}
