using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command.Interface
{
    public interface ICommand
    {
        void Invoke(Vector3 position);
    }
}
