using _app.Scripts.Managers;
using UnityEngine;

namespace _app.Scripts.Notebook {
    public class NotebookReset : MonoBehaviour {
        // Only attach to scenes that need to reset the notebook manager on load
        void Start() {
            NotebookManager.Instance.ResetNotebookData();
        }
    }
}
