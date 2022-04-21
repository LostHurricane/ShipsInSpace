using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ShipsInSpace;


namespace ShipsInSpaceInput
{
    public class InputButtonPressed : IActionOnInput <bool>
    {
        private KeyCode _key;
        private string _input;
        private Mode _mode;

        public event Action<bool> InputOnChange = delegate (bool input) { };

        public InputButtonPressed(string inputName)
        {
            _input = inputName;
            _mode = Mode.ByString;
        }

        public InputButtonPressed(KeyCode key)
        {
            _key = key;
            _mode = Mode.ByKey;
        }  

        public void GetInput()
        {
            if (_mode == Mode.ByString) InputOnChange.Invoke(Input.GetButtonDown(_input));
            else InputOnChange.Invoke(Input.GetKeyDown(_key));
        }



        private enum Mode
        {
            ByKey = 0,
            ByString = 1
        }
    }
}
