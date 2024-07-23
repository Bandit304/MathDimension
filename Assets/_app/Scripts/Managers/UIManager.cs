using UnityEngine;

namespace _app.Scripts.Managers {
    public class UIManager : MonoBehaviour
    {
        // ===== Fields =====
        [SerializeField] private Canvas environmentUI;
        [SerializeField] private Canvas quizUI;
        
        // this is a singleton as we will only need one input manager
        private static UIManager _instance;
        public static UIManager Instance
        {
            get
            {
                return _instance;
            }
        }

        // ===== Unity Lifecycle Events =====

        void Awake()
        {
            if (_instance != null && _instance != this)
            {
                // this destroys the current instance if another one exists
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
            
            environmentUI.gameObject.SetActive(true);
            quizUI.gameObject.SetActive(false);
        }

        void OnEnable() {
            if (!!environmentUI)
                environmentUI.enabled = true;
            if (!!quizUI)
                quizUI.enabled = true;
        }

        void OnDisable() {
            if (!!environmentUI)
                environmentUI.enabled = false;
            if (!!quizUI)
                quizUI.enabled = false;
        }

        // ===== Methods =====

        public void StartQuiz()
        {
            // Swap UI
            environmentUI.gameObject.SetActive(false);
            quizUI.gameObject.SetActive(true);
        }
        
        public void EndQuiz()
        {
            // Swap UI
            environmentUI.gameObject.SetActive(true);
            quizUI.gameObject.SetActive(false);
        }
    }
}
