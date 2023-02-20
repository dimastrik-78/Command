using System.Collections.Generic;
using Command.Interface;
using UnityEngine;

namespace Command
{
    public class TeleportObject : ICommand
    {
        private readonly GameObject _object;

        public TeleportObject(GameObject mainObject)
        {
            Position = new List<Vector2>();
            _object = mainObject;
            Position.Add(Vector3.zero);
        }

        public List<Vector2> Position { get; set; }

        public void Invoke(Vector3 position)
        {
            Position.Add(_object.transform.position);
            _object.transform.position = position;
        }

        public void Undo()
        {
            _object.transform.position = Position[^1];
            Position.RemoveAt(Position.Count - 1);
        }
    }
}
