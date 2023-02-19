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
        private List<ICommand> _commands;

        void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _commands.Add(_spawnObject);
                _spawnObject.Invoke((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));

                CheckCommandList();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _commands.Add(_teleportObject);
                _teleportObject.Invoke((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));

                CheckCommandList();
            }
            else if (Input.GetMouseButtonDown(2))
            {
                Undo();
            }
        }

        private void CheckCommandList()
        {
            if (_commands.Count > amountStorage)
            {
                _commands.RemoveAt(0);
            }
        }

        private void Undo()
        {
            _commands[^1].Undo();
            _commands.RemoveAt(_commands.Count - 1);
        }

        public void Get(GameObject mainObject)
        {
            _commands = new List<ICommand>();
            _spawnObject = new SpawnObject(mainObject);
            _teleportObject = new TeleportObject(mainObject);
        }
    }
}