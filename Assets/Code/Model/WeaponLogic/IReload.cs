using System.Collections;

namespace ShipsInSpace
{
    public interface IReload
    {
        public int Stock { get; }
        void Reload();
    }
}
