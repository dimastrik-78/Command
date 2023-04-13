using Command;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private int amountStorage;
        [SerializeField] private GameObject cube;

        private CommandInvoker _commandInvoker;

        void Awake()
        {
            _commandInvoker = new CommandInvoker(Instantiate(cube, Vector3.zero, Quaternion.identity), amountStorage);
            _commandInvoker.OnEnable();
        }
    }
}