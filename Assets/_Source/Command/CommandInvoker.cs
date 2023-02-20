using Command.Interface;
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
        private Queue<ICommand> _queueCommands;
        private Queue<Vector2> _queuePosition;

        void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _queueCommands.Enqueue(_spawnObject);
                _queuePosition.Enqueue(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else if (Input.GetMouseButtonDown(1))
            {
                _queueCommands.Enqueue(_teleportObject);
                _queuePosition.Enqueue(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                Complete();
            }
            else if (Input.GetMouseButtonDown(2))
            {
                Undo();
            }
        }

        private void Complete()
        {
            while (_queueCommands.Count > 0)
            {
                _commands.Add(_queueCommands.Peek());
                _queueCommands.Dequeue().Invoke(_queuePosition.Dequeue());
                
                CheckCommandList();
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
            _queueCommands = new Queue<ICommand>();
            _queuePosition = new Queue<Vector2>();
            
            _spawnObject = new SpawnObject(mainObject);
            _teleportObject = new TeleportObject(mainObject);
        }
    }
}