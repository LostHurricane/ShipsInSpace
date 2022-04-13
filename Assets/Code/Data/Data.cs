using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace ShipsInSpace
{
    [CreateAssetMenu(fileName = "DataConfig", menuName = "Configs/DataConfig", order = 0)]

    public class Data: ScriptableObject
    {

        [SerializeField]
        private List<DataPathSet> _dataPathSet ;


        public T GetData <T> (ObjectType type) where T : ScriptableObject //, IObjectData
        {
            var temp = _dataPathSet.Where(p => p.Type == type).FirstOrDefault();
            if (temp.Data == null)
            {
                temp.Data = Resources.Load<T>(Path.Combine("Data/" + temp.PathTo));
            }
            return (T)temp.Data;
        }

        [Serializable]
        private struct DataPathSet
        {
            public ObjectType Type;
            public string PathTo;
            public ScriptableObject Data;
            //public IObjectData Data;
        }
    }
    
}
