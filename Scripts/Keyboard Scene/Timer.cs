using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60;
    public Text timeText;
    private Text scoreText;
    public Text cdText;

    public GameObject[] gameObjects;

    private int score;
    private float delayTime = 5f;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            updateTimerDisplay(timeRemaining, timeText);
            if (timeRemaining <= 10)
            {
                timeText.color = Color.red;
            }
        }
        else
        {
            timeText.text = "Times Up!";
            StartCoroutine(CountdownToStart());
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].SetActive(false);
            }
            LoadSceneWithDelay("Level1");
        }

    }

    public void LoadSceneWithDelay(string sceneName)
    {
        StartCoroutine(LoadSceneDelay(sceneName, delayTime));
    }

    private IEnumerator LoadSceneDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void DeductTime()
    {
        timeRemaining -= 3f;
    }

    public void AddTime()
    {
        timeRemaining += 3f;
    }

    public void updateTimerDisplay(float timeRemaining, Text timeText)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }

    private IEnumerator CountdownToStart()
    {
        int countdownTime = 3;
        cdText.gameObject.SetActive(true);

        while (countdownTime > 0)
        {
            cdText.text = "Congratulations! You've completed the challenge just in time. Get ready for the next exciting game!\n Now, are you ready?";
            yield return new WaitForSeconds(2f);
            countdownTime--;
        }
        cdText.gameObject.SetActive(false);
    }

}