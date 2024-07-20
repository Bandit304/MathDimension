using UnityEngine;

namespace _app.Scripts.Notebook {
    [CreateAssetMenu(fileName = "NotebookData", menuName = "Scriptable Objects/NotebookData")]
    public class NotebookData : ScriptableObject {
        [TextArea]
        public string notebookContents;
    }
}
