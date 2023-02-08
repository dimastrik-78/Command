using Command.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class CommandInvoker : MonoBehaviour
    {
        private SpawnObject _spawnObject;
        private TeleportObject _teleportObject;
        private GameObject _object;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _spawnObject.Invoke((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _teleportObject.Invoke((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }

        public void Get(GameObject mainObject)
        {
            _spawnObject = new SpawnObject(mainObject);
            _teleportObject = new TeleportObject(mainObject);
        }
    }
}