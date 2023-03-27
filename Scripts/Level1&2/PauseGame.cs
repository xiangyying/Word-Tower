using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject Pausing;

    public void StopGame()
    {
        Time.timeScale = 0f;
        Pausing.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Pausing.SetActive(false);
    }

    public void timesUp()
    {
        Time.timeScale = 0f;
        Pausing.SetActive(true);
    }
}
