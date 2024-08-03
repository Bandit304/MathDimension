using _app.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _app.Scripts.Quiz
{
    public class LevelQuiz : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI questionText;
        [SerializeField] private TMP_InputField answerInput;
        [SerializeField] private Button exitButton;
        private double num1 = 0;
        private double num2 = 0;
        private double solution = 0;
        private string questionPrompt;
        private double response;
        private int opNum;
        void OnEnable()
        {
            exitButton.gameObject.SetActive(false);
            answerInput.text = "";
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            int level = OperatorManager.Instance.GetLevel();
            
            // Generate the operator this question will use, it's weighted in favor of the current level
            // 50/50 chance it will pick the current level or a previous one
            int oldOrNew = Random.Range(0, 2);
            if (oldOrNew == 1)
            {
                opNum = level;
            }
            else
            {
                opNum = Random.Range(1, level + 1);
            }
            
            string symbol = OperatorManager.Instance.GetSymbol(opNum);
            string symbolText = " " + symbol + " ";
            num1 = Random.Range(0, 16);
            num2 = Random.Range(0, 16);
            solution = OperatorManager.Instance.Calculate(num1, num2, opNum);
            questionPrompt = "Question: " + num1 + symbolText + num2 + " = ?";
            questionText.text = questionPrompt;
        }

        public void Submit()
        {
            string symbol = OperatorManager.Instance.GetSymbol(opNum);
            string symbolText = " " + symbol + " ";
            response = int.Parse(answerInput.text);

            if (solution == response)
            {
                questionText.text = num1 + symbolText + num2 + " = " + solution + "\nCorrect! You win!";
                exitButton.gameObject.SetActive(true);
            }
            else
            {
                questionText.text = num1 + symbolText + num2 + " = ?" + "\nIncorrect";
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
            InputManager.Instance.EnablePlayer();
        }
    }
}