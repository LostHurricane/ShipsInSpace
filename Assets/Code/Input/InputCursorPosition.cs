using System.Collections;
using System;
using UnityEngine;


namespace ShipsInSpaceInput
{
    public class InputCursorPosition : IActionOnInput<Vector3>
    {
        public event Action<Vector3> InputOnChange = delegate (Vector3 input) { };

        public void GetInput()
        {
            InputOnChange.Invoke(Input.mousePosition);
        }

    }
}
