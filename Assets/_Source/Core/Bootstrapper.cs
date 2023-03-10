using Command;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private CommandInvoker commandInvoker;
        [SerializeField] private GameObject cube;

        void Awake()
        {
            commandInvoker.Get(Instantiate(cube, Vector3.zero, Quaternion.identity));
        }
    }
}