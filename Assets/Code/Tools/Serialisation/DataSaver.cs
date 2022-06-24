using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ShipsInSpace
{
    public class DataSaver <T> 
    {
        private IData<T> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.txt";
        private readonly string _path;

        public  DataSaver ()
        {
            _data = new JsonData<T>();

            _path = Path.Combine(Application.dataPath, _folderName);

        }

        public void Save(T toSave)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            
            _data.Save(toSave, Path.Combine(_path, _fileName));
        }


        public T Load()
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return default;
            var loadedObject = _data.Load(file);
            return loadedObject;

            
        }

    }
}
