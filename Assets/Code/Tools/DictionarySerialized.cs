using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;

namespace ShipsInSpace
{
    /*[DataContract(Name = "Dictionary"), */[Serializable]
    public class DictionarySerialized<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        public DictionarySerialized() {}
        public DictionarySerialized(IDictionary<TKey, TValue> dictionary) : base (dictionary) { }
        public DictionarySerialized(int capacity) : base(capacity) { }

        private Dictionary<TKey, TValue> ddd = new Dictionary<TKey, TValue>();

        [SerializeField]//, DataMember]
        private List<TKey> keys = new List<TKey>();

        [SerializeField]//, DataMember]
        private List<TValue> values = new List<TValue>();


        [SerializeField]//, DataMember]
        private List<TValue> values222 = new List<TValue>();
        /*

        public Type GetDataContractType(Type type)
        {
            Console.WriteLine("GetDataContractType");
            if (typeof(Dictionary<TKey, TValue>).IsAssignableFrom(type))
            {
                return typeof(DictionarySerializer<TKey,TValue>);
            }
            return type;
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            Console.WriteLine("GetObjectToSerialize");
            if (obj is Dictionary<TKey,TValue> input)
            {
                DictionarySerializer <TKey,TValue> serializedDictionary = new DictionarySerializer<TKey, TValue> ();

                foreach (var pair in input)
                {

                    serializedDictionary.keys.Add ( pair.Key );
                    serializedDictionary.values.Add ( pair.Value );

                }
                return serializedDictionary;
            }
            return obj;
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            Console.WriteLine("GetDeserializedObject");
            if (obj is DictionarySerializer <TKey, TValue> serializer)
            {
                Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
                foreach (var element in serializer)
                {
                    dictionary.Add(element.Key, element.Value);
                }
                return dictionary;
            }
            return obj;
        }
        */

        

        [OnSerializing]
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();

            foreach (var pair in ddd /*this*/)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        [OnDeserialized]
        public void OnAfterDeserialize()
        {
            this.Clear();

            if (keys.Count != values.Count)
                throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

            for (int i = 0; i < keys.Count; i++)
            {

                //this[this.keys[i]] = this.values[i];
                ddd[keys[i]] = values[i];
            }
                
        }

    }
}
