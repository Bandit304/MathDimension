using UnityEngine;

public class UIManager : MonoBehaviour
{
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
