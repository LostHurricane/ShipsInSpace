using System;

namespace ShipsInSpace
{
    [Serializable]
    public sealed class Unit
    {
        public string Type;
        public int Health;

        public override string ToString() => $"Unit {Type} type {Type} health {Health}";
    }
}
