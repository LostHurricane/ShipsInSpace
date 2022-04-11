using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShipsInSpace
{
    public class ProjectilePool : IPool<InteractiveObjectView>
    {
        private readonly HashSet<InteractiveObjectView> _projectilePool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        private RegularFactory<InteractiveObjectView> _projectileFactory;

        public ProjectilePool (InteractiveObjectView example, int capacityPool)
        {
            _projectilePool = new HashSet<InteractiveObjectView>();
            _projectileFactory = new RegularFactory<InteractiveObjectView>(example);
            _capacityPool = capacityPool;
            if (!_rootPool)
                _rootPool = new GameObject(example.name + "Pool").transform;
            
        }

        public InteractiveObjectView GetNewObject()
        {
            return GetFromPool(_projectilePool);
        }

        private InteractiveObjectView GetFromPool(HashSet<InteractiveObjectView> pool)
        {
            var instance = pool.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (instance == null)
            {
                for (var i = 0; i < _capacityPool; i++)
                {
                    var item = _projectileFactory.GetNewObject();
                    pool.Add(item);
                    ReturnToPool(item.Transform);
                }

                instance = GetFromPool(pool);
            }
            return instance;

        }


        public void ReturnToPool(Transform transform)
        {
            if (_projectilePool.Contains(transform.GetComponent<InteractiveObjectView>()))
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
