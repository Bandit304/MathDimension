using _app.Scripts;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using _app.Scripts.Managers;

public class LevelQuiz : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI questionText;
    [SerializeField] private TMP_InputField answerInput;
    [SerializeField] private Button exitButton;
    private double num1 = 0;
    private double num2 = 0;
    private double solution = 0;
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
        string symbol = OperatorManager.Instance.GetSymbol();
        string symbolText = " " + symbol + " ";
        num1 = Random.Range(0, 16);
        num2 = Random.Range(0, 16);
        solution = OperatorManager.Instance.Calculate(num1, num2);
        questionPrompt = "Question: " + num1 + symbolText + num2 + " = ?";
        questionText.text = questionPrompt;
    }

    public void Submit()
    {
        response = int.Parse(answerInput.text);

        if (solution == response)
        {
            questionText.text = num1 + " + " + num2 + " = " + solution + "\nCorrect!";
            exitButton.gameObject.SetActive(true);
        }
        else
        {
            questionText.text = num1 + " + " + num2 + " = ?" + "\nIncorrect";
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