using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    const int RIGHT_ANSWERS_TO_WIN = 1;

    public enum Player { P1, P2 };
    const string PLAYER1 = "Player 1";
    const string PLAYER2 = "Player 2";

    Color colorPlayer1 = new Color(0f, 0.5f, 0.17f);
    Color colorPlayer2 = new Color(0.9f, 0.55f, 0f);

    public Text questionText;
    public Text playerText;
    public Image playerImage;
    public Transform answerArea;
    public GameObject buttonAnswer;

    public Data inputData;
    public Question currentQuestion;
    public List<Question> questions;
    public int rightAnswers;
    public Player currentPlayer;

    void Start()
    {
        initData();
        readInputData();
        fillQuestionArea();
        fillAnswerArea();
    }

    private void initData()
    {
        rightAnswers = 0;
        questions.Clear();
        currentPlayer = Player.P1;
        playerText.text = PLAYER1;
        playerImage.color = colorPlayer1;
    }

    private void readInputData()
    {
        TextAsset data = Resources.Load<TextAsset>("InputData");
        inputData = JsonUtility.FromJson<Data>(data.ToString());
        questions = inputData.data;
    }

    private void fillQuestionArea()
    {
        System.Random rnd = new System.Random();
        int random = rnd.Next(0, (questions.Count + 1));
        currentQuestion = questions[random];
        questionText.text = currentQuestion.question;
    }

    private void fillAnswerArea()
    {
        cleanAnswerArea();
        float height = -100;

        foreach (Question q in questions)
        {
            GameObject newButton = Instantiate(buttonAnswer);
            newButton.transform.parent = answerArea;

            newButton.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
            newButton.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);
            newButton.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f);
            newButton.GetComponent<RectTransform>().offsetMin = new Vector2(100, 0);
            newButton.GetComponent<RectTransform>().offsetMax = new Vector2(-100, 100);
            newButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, height);
            newButton.GetComponent<Image>().enabled = true;
            newButton.GetComponent<Button>().enabled = true;
            FillListener(q, newButton);

            newButton.GetComponentInChildren<Text>().text = q.answer;
            newButton.GetComponentInChildren<Text>().enabled = true;
            height -= 120;
        }
    }

    private void FillListener(Question question, GameObject newButton)
    {
        newButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            AnswerSelected(question);
        });
    }

    private void AnswerSelected(Question question)
    {
        if (isRightAnswer(question))
        {
            rightAnswers++;

            if (player1Wins())
            {
                OpenFinalScreen.LaunchPlayScreen();
            }
            else if (player2Wins())
            {
                OpenFinalScreen.LaunchPlayScreen();
            }
        }
        else
        {
            changePlayer();
        }

        fillQuestionArea();
    }

    private void changePlayer()
    {
        if (currentPlayer.Equals(Player.P1))
        {
            currentPlayer = Player.P2;
            playerText.text = PLAYER2;
            playerImage.color = colorPlayer2;
        }
        else
        {
            currentPlayer = Player.P1;
            playerText.text = PLAYER1;
            playerImage.color = colorPlayer1;
        }
        rightAnswers = 0;
    }

    private bool isRightAnswer(Question question)
    {
        return question.Equals(currentQuestion);
    }

    private bool player1Wins()
    {
        if (currentPlayer.Equals(Player.P1)) {
            return rightAnswers >= RIGHT_ANSWERS_TO_WIN;
        }
        return false;
    }

    private bool player2Wins()
    {
        if (currentPlayer.Equals(Player.P2))
        {
            return rightAnswers >= RIGHT_ANSWERS_TO_WIN;
        }
        return false;
    }

    private void cleanAnswerArea()
    {
        foreach (Transform child in answerArea.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
