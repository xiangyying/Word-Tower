using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public GameObject[] gameObjects;
    public Button leftButton;
    public Button rightButton;
    private int currentGameObjectIndex = 0;

    void Start()
    {
        DisplayCurrentGameObject();
        leftButton.onClick.AddListener(LeftButtonClicked);
        rightButton.onClick.AddListener(RightButtonClicked);
    }

    void LeftButtonClicked()
    {
        currentGameObjectIndex--;
        if (currentGameObjectIndex < 0)
        {
            currentGameObjectIndex = gameObjects.Length - 1;
        }
        DisplayCurrentGameObject();
    }

    void RightButtonClicked()
    {
        currentGameObjectIndex++;
        if (currentGameObjectIndex >= gameObjects.Length)
        {
            currentGameObjectIndex = 0;
        }
        DisplayCurrentGameObject();
    }


    void DisplayCurrentGameObject()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (i == currentGameObjectIndex)
            {
                gameObjects[i].SetActive(true);
            }
            else
            {
                gameObjects[i].SetActive(false);
            }
        }
    }
}
