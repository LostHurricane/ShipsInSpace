using UnityEngine;

namespace ShipsInSpace
{
    public interface IRotation
    {
        void Rotation(Vector3 direction, float deltaTime);
    }

}
