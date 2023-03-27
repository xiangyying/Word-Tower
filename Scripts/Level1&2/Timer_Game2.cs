using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer_Game2 : MonoBehaviour
{
    public Text timeText;
    private float timeRemaining = 60;

    public Canvas canvas;
    public GameObject GO;
    public GameObject GO2;
    public Text resultText;

    public Timer_Game timergame;

    private int score;
    private float time;

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        timeRemaining = score * 8;
        timeText.text = timergame.FormatTime(timeRemaining);
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timeText.text = timergame.FormatTime(timeRemaining);
            if (timeRemaining <= 10)
            {
                timeText.color = Color.red;
            }
        }
        else // This is if timing is 0
        {
            resultText.gameObject.SetActive(true);
            timeText.text = "00:00";
            GO.SetActive(false);
            GO2.SetActive(false);
            timergame.LoadSceneWithDelay("End_Screen");
        }
    }
}
