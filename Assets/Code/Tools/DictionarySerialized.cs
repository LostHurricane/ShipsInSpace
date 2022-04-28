using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System;

namespace ShipsInSpace
{
    [Serializable]
    public abstract class DictionarySerialized<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver, ISerializable
    {
        [SerializeField]
        private List<TKey> keys = new List<TKey>(1);

        [SerializeField]
        private List<TValue> values = new List<TValue>(1);

        // save the dictionary to lists
        public void OnBeforeSerialize()
        {
            keys.Clear();
            values.Clear();
            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        // load dictionary from lists
        public void OnAfterDeserialize()
        {
            this.Clear();

            if (keys.Count != values.Count)
                throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));

            for (int i = 0; i < keys.Count; i++)
                this.Add(keys[i], values[i]);
        }

    }
}
