using System.Collections.Generic;
using UnityEngine;

namespace Command.Interface
{
    public interface ICommand
    {
        public List<Vector2> Position { get; set; }

        void Invoke(Vector3 position);
        void Undo();
    }
}
