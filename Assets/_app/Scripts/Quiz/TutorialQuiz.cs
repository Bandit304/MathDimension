using UnityEngine;
using TMPro;

public class TutorialQuiz : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI whiteboardText;
    private int num1 = 0;
    private int num2 = 0;
    private int solution = 0;
    private string questionPrompt;
    void OnEnable()
    {
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
}