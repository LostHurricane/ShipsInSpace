using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShipsInSpace
{
    public class ProjectilePool <T> : IPool<T> where T : UnityEngine.Object, IView, ITransform, IPoolable
    {
        private readonly HashSet<T> _projectilePool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        private RegularFactory<T> _projectileFactory;

        public ProjectilePool (T example, int capacityPool)
        {
            _projectilePool = new HashSet<T>();
            _projectileFactory = new RegularFactory<T>(example);
            _capacityPool = capacityPool;
            if (!_rootPool)
                _rootPool = new GameObject(example.GameObject.name + "Pool").transform;
            
        }

        public T GetNewObject()
        {
            return GetFromPool(_projectilePool);
        }

        private T GetFromPool(HashSet<T> pool)
        {
            var instance = pool.FirstOrDefault(a => !a.GameObject.activeSelf);
            if (instance == null)
            {
                for (var i = 0; i < _capacityPool; i++)
                {
                    var item = _projectileFactory.GetNewObject();
                    pool.Add(item);
                    ReturnToPool(item.Transform);
                    item.OnReturnToPool += ReturnToPool;
                }

                instance = GetFromPool(pool);
            }
            return instance;

        }


        public void ReturnToPool(Transform transform)
        {
            if (_projectilePool.Contains(transform.GetComponent<T>()))
            {
                transform.gameObject.SetActive(false);
                transform.SetParent(_rootPool);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
            }
            else
                throw new Exception("Attempt to return to pool wrong object");
        }
    }
}
