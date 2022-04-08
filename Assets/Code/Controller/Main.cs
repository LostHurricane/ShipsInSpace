using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShipsInSpace
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private InteractiveObjectView _player;

        private Controllers _controllers;

        [SerializeField]
        private Data _gameData;


        // Start is called before the first frame update
        void Awake()
        {
            _controllers = new Controllers();
            new Initializer(_controllers, _gameData);
            _controllers.Initialization();
        }

        // Update is called once per frame
        void Update()
        {
            _controllers.Execute(Time.deltaTime);
        
        }

        private void FixedUpdate()
        {
            _controllers.FixedExecute(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }
}
