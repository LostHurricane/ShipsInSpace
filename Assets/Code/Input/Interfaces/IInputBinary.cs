using System;

namespace ShipsInSpaceInput
{
    public interface IInputBinary : IInput
    {
        event Action<bool> InputOnChange;
    }
}
