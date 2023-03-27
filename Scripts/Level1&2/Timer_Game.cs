using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer_Game : MonoBehaviour
{
    public Text timeText;
    private float timeRemaining = 60;

    public Canvas canvas;
    public GameObject GO;
    public GameObject GO2;
    public Text resultText;

    private int score;
    private float delayTime = 5f;

    private void Start()
    {

        score = PlayerPrefs.GetInt("Score");
        timeRemaining = score * 8;
        timeText.text = FormatTime(timeRemaining);
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timeText.text = FormatTime(timeRemaining);

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
            LoadSceneWithDelay("End_Screen");
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

    public IEnumerator LoadLevelWithDelay(string sceneName)
    {
        PlayerPrefs.SetFloat("TimeRemaining", timeRemaining);
        yield return new WaitForSeconds(delayTime);

        // Load the next scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Wait until the next scene has loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Set the time remaining from the previous scene
        float savedTimeRemaining = PlayerPrefs.GetFloat("TimeRemaining");
        Timer_Game timer = FindObjectOfType<Timer_Game>();
        if (timer != null)
        {
            timer.timeRemaining = savedTimeRemaining;
            timer.timeText.text = FormatTime(timer.timeRemaining);
        }
    }

    public string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
