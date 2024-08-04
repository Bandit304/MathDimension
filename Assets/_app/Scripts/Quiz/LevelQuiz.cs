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
            switch (level)
            {
                case 1:
                    SceneManager.LoadScene (sceneName:"Level2");
                    break;
                case 2:
                    SceneManager.LoadScene(sceneName: "Level3");
                    break;
                case 3:
                    SceneManager.LoadScene(sceneName: "Level4");
                    break;
                case 4:
                    SceneManager.LoadScene (sceneName:"Level5");
                    break;
                case 5:
                    SceneManager.LoadScene(sceneName: "Level6");
                    break;
                case 6:
                    SceneManager.LoadScene(sceneName: "Level7");
                    break;
                case 7:
                    SceneManager.LoadScene(sceneName: "Level8");
                    break;
                case 8:
                    SceneManager.LoadScene(sceneName: "Level9");
                    break;
                default:
                    SceneManager.LoadScene(sceneName: "TitleScreen");
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