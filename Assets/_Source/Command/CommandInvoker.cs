using Command.Interface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class CommandInvoker : MonoBehaviour
    {
        [SerializeField] private int amountStorage;

        private SpawnObject _spawnObject;
        private TeleportObject _teleportObject;
        private GameObject _object;
        private List<ICommand> commands;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                commands.Add(_spawnObject);
                _spawnObject.Invoke((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else if (Input.GetMouseButtonDown(1))
            {
                commands.Add(_teleportObject);
                _teleportObject.Invoke((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else if (Input.GetMouseButtonDown(2))
            {
                Undo();
            }
        }

        private void Undo()
        {
            //Debug.Log(commands.);
            //_teleportObject.Invoke((Vector2)commands.l.Position);
        }

        public void Get(GameObject mainObject)
        {
            _spawnObject = new SpawnObject(mainObject);
            _teleportObject = new TeleportObject(mainObject);
        }
    }
}