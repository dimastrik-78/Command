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
            _mainObject = spawnObject;
        }

        public void Invoke(Vector3 position)
        {
            if (!_mainObject.activeSelf)
            {
                _mainObject.SetActive(true);
                _mainObject.transform.position = position;
            }
        }
    }
}
