using _app.Scripts.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace _app.Scripts.Quiz
{
    public class LevelQuiz : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI questionText;
        [SerializeField] private TMP_InputField answerInput;
        [SerializeField] private Button submitButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Button nextButton;
        
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
            exitButton.gameObject.SetActive(false);
            correctAnswers = 0;
            incorrectAnswers = 0;
            answerInput.text = "";
            level = OperatorManager.Instance.GetLevel();
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            nextButton.gameObject.SetActive(false);
            
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
            response = double.Parse(answerInput.text);

            if (solution == response)
            {
                submitButton.gameObject.SetActive(false);
                correctAnswers++;
                if (correctAnswers < 5)
                {
                    questionText.text = num1 + symbolText + num2 + " = " + solution + 
                                        "\nCorrect! " + (5 - correctAnswers) + " to go!";
                }
                else
                {
                    questionText.text = num1 + symbolText + num2 + " = " + solution + 
                                        "\nCorrect! Next Level";
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
            switch (level)
            {
                case 1:
                    SceneManager.LoadScene (sceneName:"Level1");
                    break;
            }
        }

        public void ResetLevel()
        {
            OperatorManager.Instance.NewOperator();
            Exit();
        }
    }
}