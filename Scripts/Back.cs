using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    // Load Scenes for each Menu, Difficulty and Single Game
    public void BackMenu()
    {
        SceneManager.LoadScene("Start_Screen");
    }

    public void BackDifficulty()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void BackSingleGame()
    {
        SceneManager.LoadScene("Level1");
    }

    // For Testing (Timer Doesn't starts)
    public void BackKeyboard()
    {
        SceneManager.LoadScene("Keyboard");
    }
}
