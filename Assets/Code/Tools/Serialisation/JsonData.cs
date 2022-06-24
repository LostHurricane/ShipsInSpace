using System.IO;
using UnityEngine;
using Newtonsoft.Json;

namespace ShipsInSpace
{
    public class JsonData <T> : IData<T>
    {
        public void Save(T data, string path = null)
        {
            //var str = JsonUtility.ToJson(data);
            var str = JsonConvert.SerializeObject(data);

            File.WriteAllText(path, str);
        }

        public T Load(string path = null)
        {
            var str = File.ReadAllText(path);
            //return JsonUtility.FromJson<T>(str);
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
