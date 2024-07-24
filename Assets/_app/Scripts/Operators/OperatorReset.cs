using _app.Scripts.Managers;
using UnityEngine;

namespace _app.Scripts.Operators
{
    public class OperatorReset : MonoBehaviour
    {
        // Only attach to scenes that need to initialize the operator array on load
        void Start() 
        {
            OperatorManager.Instance.InitializeArr();
        }
    }
}
