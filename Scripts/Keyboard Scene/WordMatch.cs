using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordMatch : MonoBehaviour
{
    public Text inputText;
    public Text wordText;
    public Text scoreText;
    public Text timeText;
    public Canvas FinishCanvas;
    public Text resultText;

    public GameObject GO;
    public GameObject GO2;
    public GameObject GO3;

    public DVORAK dvorakScript;
    public Timer timerScript;

    private string difficulty;
    private string word;
    private int score = 0;
    private string Txt;

    private string[] Currentword;
    // private string[] easyWords = { "him", "who", "you", "she" };
    private string[] easyWords = { "him", "who", "you", "she", "no", "yes", "cat", "dog", "bus", "ant", "bug", "fly", "zoo", "car", "hat", "pen", "egg", "dad", "mon", "son", "rat", "sun", "bag", "see" };
    private string[] mediumWords = { "apple", "banana", "cherry", "date", "cookie", "candy", "flower", "elephant", "igloo", "kitten", "monkey", "orange", "pizza", "quilt", "robot", "sugar", "tiger", "berry", "pumpkin", "jellyfish", "seagull", "snowman", "snow", "popcorn" };
    private string[] hardWords = { "elderberry", "playground", "strawberry", "chocolate", "rainforest", "experience", "adventure", "crocodile", "basketball", "firefighters", "kangaroo", "aquarium", "sunflower", "asparagus", "astronaut", "hippopotamus", "xylophone", "cauliflower", "marshmallow", "chandelier", "chimpanzee", "watermelon", "pencilcase" };

    private void Start()
    {
        Ready();
        difficulty = PlayerPrefs.GetString("Difficulty", "Easy");
        Txt = PlayerPrefs.GetString("input_words", " ");
        WordsGeneration();
        GenerateWord();
        UpdateUI();
    }

    private void WordsGeneration()
    {
        if (difficulty == "Hard")
        {
            Currentword = hardWords;
        }
        else if (difficulty == "Medium")
        {
            Currentword = mediumWords;
        }
        else
        {
            Currentword = easyWords;
        }
    }

    private void GenerateWord()
    {
        int index = Random.Range(0, Currentword.Length);
        word = Currentword[index];
        wordText.text = word;

        List<string> wordList = new List<string>(Currentword);
        wordList.RemoveAt(index);
        Currentword = wordList.ToArray();
    }

    private void UpdateUI()
    {
        inputText.text = " ";
        scoreText.text = "Score: " + score;
    }

    public void CheckMatch()
    {
        string input = inputText.text.ToLower();

        if (input == word) // If input is equal to the word displayed
        {
            score++;
            PlayerPrefs.SetInt("Score", score);
            inputText.text = "";
            Txt = "";
            if (Currentword.Length == 0) // The list of CurrentWords is empty
            {
                Debug.Log("Well Done!");
                resultText.text = "You have completed the wordings, Well Done!";
                GO.SetActive(false); // Pause Menu
                GO2.SetActive(false); // Keyboard
                FinishCanvas.gameObject.SetActive(true);
                resultText.gameObject.SetActive(true);

                string matchedWords = PlayerPrefs.GetString("MatchedWords", "");
                matchedWords += input + " ";
                PlayerPrefs.SetString("MatchedWords", matchedWords);

                timerScript.LoadSceneWithDelay("Level1");
            }
            else if (Currentword.Length > 0)
            {
                GenerateWord();
                UpdateUI();

                string matchedWords = PlayerPrefs.GetString("MatchedWords", "");
                matchedWords += input + " ";
                PlayerPrefs.SetString("MatchedWords", matchedWords);

                dvorakScript.Back();
            }
        }
        else
        {
            timerScript.DeductTime(); // Deduct time
            timerScript.updateTimerDisplay(timerScript.timeRemaining, timeText); // Update timer display
            Debug.Log("Wrong Word");
            dvorakScript.Back();
        }
    }

    private void Ready()
    {
        timerScript.AddTime(); // Add time
        GO2.SetActive(false); // Keyboard
        GO.SetActive(false); // Pause Menu
        Time.timeScale = 0f;
        StartCoroutine(DisplayGameObjectsRoutine());
    }

    IEnumerator DisplayGameObjectsRoutine()
    {
        // Display first game object for 3 seconds
        GO3.SetActive(true);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(3f);

        GO3.SetActive(false);
        GO2.SetActive(true); // Keyboard
        GO.SetActive(true); // Pause Menu

    }
}
