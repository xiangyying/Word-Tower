using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class History : MonoBehaviour
{
    public Text matchedWordsText;
    public Text scoreText;

    void Start()
    {
        int score = PlayerPrefs.GetInt("Score"); // Retrieve the score from PlayerPrefs
        scoreText.text = score.ToString();
        string matchedWords = PlayerPrefs.GetString("MatchedWords", ""); // Retrieve the words from PlayerPrefs
        matchedWordsText.text = matchedWords;
    }
}
