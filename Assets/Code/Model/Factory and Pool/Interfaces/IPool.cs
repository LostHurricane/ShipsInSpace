using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ShipsInSpace
{
    public interface IPool <T> : IFactory <T>
    {
        void ReturnToPool();
    }
}
