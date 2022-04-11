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

        private Camera _currentCamera;


        ProjectilePool projectilePool;


        // Start is called before the first frame update
        void Awake()
        {
            _currentCamera = Camera.current;
            _controllers = new Controllers();
            new Initializer(_controllers, _gameData);
            _controllers.Initialization();


            #region TestBlock

            projectilePool = new ProjectilePool(_gameData.GetData<ObjectData>(ObjectType.Bullet).GetPrefab().GetComponent<InteractiveObjectView>(), 4);

            #endregion

        }

        // Update is called once per frame
        void Update()
        {
            _controllers.Execute(Time.deltaTime);


            if (Input.GetKeyDown(KeyCode.Space))
            {
                projectilePool.GetNewObject();
            }
        
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
