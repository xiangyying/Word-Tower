using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End_Game : MonoBehaviour
{
    // private audioSource finishSound;
    public Text matchedWordsText;
    public Text scoreText;
    public Text timeText;

    private float startTime;

    void Start()
    {
        startTime = Time.time;
        int score = PlayerPrefs.GetInt("Score"); // Retrieve the score from PlayerPrefs
        scoreText.text = score.ToString();
        string matchedWords = PlayerPrefs.GetString("MatchedWords", "");
        matchedWordsText.text = matchedWords;
        // float timeTaken = PlayerPrefs.GetFloat("TimeTaken", 0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
