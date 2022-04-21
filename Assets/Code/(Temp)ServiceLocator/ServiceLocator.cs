using System;
using ShipsInSpaceSV;
using System.Collections.Generic;


namespace ShipsInSpace
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _service—ontainer = new Dictionary<Type, object>();
        public static void SetService<T>(T value) where T : class, IService
        {
            var typeValue = typeof(T);
            if (!_service—ontainer.ContainsKey(typeValue))
            {
                _service—ontainer[typeValue] = value;
            }
        }
        public static T Resolve<T>()
        {
            var type = typeof(T);
            if (_service—ontainer.ContainsKey(type))
            {
                return (T)_service—ontainer[type];
            }
            return default;
        }

    }
}
