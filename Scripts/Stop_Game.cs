using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stop_Game : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject Keyboard;
    public GameObject Input;

    public void StopGame()
    {
        Time.timeScale = 0f;
        Keyboard.SetActive(false);
        Input.SetActive(false);
        Canvas.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Keyboard.SetActive(true);
        Input.SetActive(true);
        Canvas.SetActive(false);
    }

    public void timesUp()
    {
        Time.timeScale = 0f;
        Canvas.SetActive(true);
    }
}
