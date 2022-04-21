using System;

namespace ShipsInSpaceInput
{
    public interface IActionOnInput <T> : IInput
    {
        event Action<T> InputOnChange;
    }
}
