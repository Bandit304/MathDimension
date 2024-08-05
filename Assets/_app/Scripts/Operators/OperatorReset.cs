using _app.Scripts.Managers;
using UnityEngine;

namespace _app.Scripts.Operators
{
    // Only attach to scenes that need to initialize the operator array on load
    public class OperatorReset : MonoBehaviour
    {
        public static OperatorReset Instance { get; private set; }

        // Awake is called once before the first execution of Start after the MonoBehaviour is created
        void Awake() {
            if (!Instance)
                Instance = this;
            else
                Destroy(this);
        }

        public void ResetOperator() {
            if (!!OperatorManager.Instance)
                OperatorManager.Instance.InitializeArr();
        }
    }
}
