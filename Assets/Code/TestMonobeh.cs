using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class TestMonobeh : MonoBehaviour
    {
        private List<Unit> _units;
        private DataSaver<Root[]> _saver;

        private Dictionary<string, List<Unit>> _unitsSortedByType;

        void Awake()
        {
            /*
            _saver = new DataSaver<Root[]> ();
            _units = new List<Unit>();
            _unitsSortedByType = new Dictionary<string, List<Unit>>();

            foreach (var root in _saver.Load())
            {
                _units.Add(root.unit);
            }

            foreach (var unit in _units)
            {
                if(!_unitsSortedByType.ContainsKey(unit.Type))
                {
                    _unitsSortedByType.Add(unit.Type, new List<Unit>());
                }
                _unitsSortedByType[unit.Type].Add(unit);
            }

            Debug.Log($"Units sorted has {_unitsSortedByType.Count} types");

            foreach (var pair in _unitsSortedByType)
            {
                Debug.Log($"Type {pair.Key}");
                foreach (var unit in pair.Value)
                {
                    Debug.Log(unit.ToString());
                }
            }
            */
            Debug.Log(PointsInterpreter.Interpret(100));

            Debug.Log(PointsInterpreter.Interpret (1000));
            Debug.Log(PointsInterpreter.Interpret (2123.32f));
            Debug.Log(PointsInterpreter.Interpret(30040));
            Debug.Log(PointsInterpreter.Interpret(2000000));


        }

        public class Root
        {
            public Unit unit { get; set; }

            public override string ToString() => $"type {unit.Type} health {unit.Health}";

        }
    }

    
}
