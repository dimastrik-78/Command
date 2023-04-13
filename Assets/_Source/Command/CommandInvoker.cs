using Command.Interface;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Command
{
    public class CommandInvoker
    {
        private readonly int _amountStorage;
        
        private SpawnObject _spawnObject;
        private TeleportObject _teleportObject;
        private GameObject _object;
        private List<ICommand> _commands;
        private Queue<ICommand> _queueCommands;
        private Queue<Vector2> _queuePosition;
        private Listener _listener;

        public CommandInvoker(GameObject mainObject, int amountStorage)
        {
            Init(mainObject);
            _amountStorage = amountStorage;
        }

        public void OnEnable()
        {
            _listener.Enable();
            _listener.Input.Spawn.performed += context => Spawn();
            _listener.Input.Teleport.performed += context => Teleport();
            _listener.Input.Complete.performed += context => Complete();
            _listener.Input.Undo.performed += context => Undo();
        }

        public void OnDisable()
        {
            _listener.Input.Spawn.performed -= context => Spawn();
            _listener.Input.Teleport.performed -= context => Teleport();
            _listener.Input.Complete.performed -= context => Complete();
            _listener.Input.Undo.performed -= context => Undo();
            _listener.Disable();
        }

        private void Spawn()
        {
            _queueCommands.Enqueue(_spawnObject);
            _queuePosition.Enqueue(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        
        private void Teleport()
        {
            _queueCommands.Enqueue(_teleportObject);
            _queuePosition.Enqueue(Camera.main.ScreenToWorldPoint(Input.mousePosition));
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
            if (_commands.Count > _amountStorage)
            {
                _commands.RemoveAt(0);
            }
        }

        private void Undo()
        {
            if (_commands.Count > 0)
            {
                _commands[^1].Undo();
                _commands.RemoveAt(_commands.Count - 1);
            }
        }

        private void Init(GameObject mainObject)
        {
            _commands = new List<ICommand>();
            _queueCommands = new Queue<ICommand>();
            _queuePosition = new Queue<Vector2>();
            _listener = new Listener();
            
            _spawnObject = new SpawnObject(mainObject);
            _teleportObject = new TeleportObject(mainObject);
        }
    }
}