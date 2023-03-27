using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move_Scenes : MonoBehaviour
{
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    private void Start()
    {
        easyButton.onClick.AddListener(() => { SetDifficulty("Easy"); });
        mediumButton.onClick.AddListener(() => { SetDifficulty("Medium"); });
        hardButton.onClick.AddListener(() => { SetDifficulty("Hard"); });
    }

    public void GoHistory()
    {
        SceneManager.LoadScene("History");
    }

    public void GoSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void GoInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void GoDifficultyLevel()
    {
        SceneManager.LoadScene("Difficulty");
        PlayerPrefs.DeleteAll();
    }

    public void SetDifficulty(string difficulty)
    {
        PlayerPrefs.SetString("Difficulty", difficulty);
        Debug.Log("Move_Scenes Difficulty set to " + difficulty);
        SceneManager.LoadScene("Keyboard");
    }
}
