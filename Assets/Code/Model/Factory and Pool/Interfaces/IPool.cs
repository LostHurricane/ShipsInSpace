using UnityEngine;


namespace ShipsInSpace
{
    public interface IPool <T> : IFactory <T>
    {
        void ReturnToPool(Transform transform);
    }
}
