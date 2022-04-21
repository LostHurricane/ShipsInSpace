using System.Collections;
using System;
using UnityEngine;


namespace ShipsInSpaceInput
{
    public class InputAxis : IActionOnInput<float>
    {
        public event Action<float> InputOnChange = delegate (float input) { };

        private string _axis;

        public InputAxis (string axis)
        {
            _axis = axis;
        }

        public void GetInput()
        {
            InputOnChange.Invoke(Input.GetAxis(_axis));
        }
    }
}
