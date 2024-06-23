using _app.Scripts;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialQuiz : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI whiteboardText;
    [SerializeField] private TMP_InputField answerInput;
    [SerializeField] private Button exitButton;
    private int num1 = 0;
    private int num2 = 0;
    private int solution = 0;
    private string questionPrompt;
    private int response;
    void OnEnable()
    {
        exitButton.gameObject.SetActive(false);
        answerInput.text = "";
        GenerateQuestion();
    }

    private void GenerateQuestion()
    {
        num1 = Random.Range(0, 16);
        num2 = Random.Range(0, 16);
        solution = num1 + num2;
        questionPrompt = "Question: " + num1 + " + " + num2 + " = ?";
        whiteboardText.text = questionPrompt;
    }

    public void Submit()
    {
        response = int.Parse(answerInput.text);

        if (solution == response)
        {
            whiteboardText.text = num1 + " + " + num2 + " = " + solution + "\nCorrect!";
            exitButton.gameObject.SetActive(true);
        }
        else
        {
            whiteboardText.text = num1 + " + " + num2 + " = " + solution + "\nIncorrect";
        }
    }

    public void Exit()
    {
        EnableMovement();
        UIManager.Instance.EndQuiz();
    }
    
    private void EnableMovement()
    {
        Cursor.lockState = CursorLockMode.Locked;
        InputManager.Instance.enabled = true;
    }
}