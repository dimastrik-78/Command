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
        }

        public void Invoke(Vector3 position)
        {
            _object.transform.position = position;
        }
    }
}
