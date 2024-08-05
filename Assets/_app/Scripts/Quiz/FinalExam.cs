using _app.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace _app.Scripts.Quiz
{
    public class FinalExam : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI questionText;
        [SerializeField] private TMP_InputField answerInput;
        [SerializeField] private Button submitButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button resetButton;
        
        private double num1 = 0;
        private double num2 = 0;
        private double solution = 0;
        private string questionPrompt;
        private double response;
        private int opNum;
        private int correctAnswers;
        private int incorrectAnswers;
        private int level;
        private bool next = false;
        void OnEnable()
        {
            submitButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(false);
            correctAnswers = 0;
            incorrectAnswers = 0;
            answerInput.text = "";
            level = OperatorManager.Instance.GetLevel();
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            nextButton.gameObject.SetActive(false);
            
            // Picks a random operator that isn't a traditional one
            opNum = Random.Range(5, 10);
            
            string symbol = OperatorManager.Instance.GetSymbol(opNum);
            string symbolText = " " + symbol + " ";
            num1 = Random.Range(0, 16);
            // checks if the operator is basic division to prevent /0
            if (symbol == "/")
            {
                num2 = Random.Range(1, 16);
            }
            else
            {
                num2 = Random.Range(0, 16);
            }
            solution = OperatorManager.Instance.Calculate(num1, num2, opNum);
            questionPrompt = "Question: " + num1 + symbolText + num2 + " = ?";
            questionText.text = questionPrompt;
        }

        public void Submit()
        {
            string symbol = OperatorManager.Instance.GetSymbol(opNum);
            string symbolText = " " + symbol + " ";
            response = double.Parse(answerInput.text);

            if (solution == response)
            {
                submitButton.gameObject.SetActive(false);
                correctAnswers++;
                if (correctAnswers < 10)
                {
                    questionText.text = num1 + symbolText + num2 + " = " + solution + 
                                        "\nCorrect! " + (10 - correctAnswers) + " to go!";
                }
                else
                {
                    questionText.text = num1 + symbolText + num2 + " = " + solution + 
                                        "\nCorrect! You've Graduated!";
                    next = true;
                }
                nextButton.gameObject.SetActive(true);
            }
            else
            {
                incorrectAnswers++;
                if (incorrectAnswers < 3)
                {
                    questionText.text = num1 + symbolText + num2 + " = ?" + "\nIncorrect. " + (3 - incorrectAnswers) + " tries remaining.";
                }
                else
                {
                    questionText.text = num1 + symbolText + num2 + " = ?" + "\nIncorrect. Reset to try again.";
                    submitButton.gameObject.SetActive(false);
                    resetButton.gameObject.SetActive(true);
                }
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

        public void NextQuestion()
        {
            if (next)
            {
                ChangeLevel();
            }
            else
            {
                answerInput.text = "";
                submitButton.gameObject.SetActive(true);
                GenerateQuestion();
            }
        }

        private void ChangeLevel()
        {
            SceneManager.LoadScene("End Screen");
        }

        public void ResetLevel()
        {
            Exit();
        }
    }
}