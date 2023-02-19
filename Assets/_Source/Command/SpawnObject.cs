using Command.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Command
{
    public class SpawnObject : ICommand
    {
        private GameObject _mainObject;

        public SpawnObject(GameObject spawnObject)
        {
            Position = new List<Vector3>();
            _mainObject = spawnObject;
        }

        public List<Vector3> Position { get; set; }

        public void Invoke(Vector3 position)
        {
            if (!_mainObject.activeSelf)
            {
                _mainObject.SetActive(true);
            }
        }

        public void Undo()
        {
            _mainObject.SetActive(false);
        }
    }
}
