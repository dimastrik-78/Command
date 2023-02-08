using Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Command
{
    public class TeleportObject : ICommand
    {
        private GameObject _object;

        public TeleportObject(GameObject mainObject)
        {
            _object = mainObject;
            Position = Vector3.zero;
        }

        public Vector3 Position { get; set; }

        public void Invoke(Vector3 position)
        {
            Position = position;
            _object.transform.position = position;
        }
    }
}
