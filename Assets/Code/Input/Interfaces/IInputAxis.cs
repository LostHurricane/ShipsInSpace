using System;

namespace ShipsInSpaceInput
{
    public interface IInputAxis : IInput
    {
        event Action<float> InputOnChange;
    }
}
