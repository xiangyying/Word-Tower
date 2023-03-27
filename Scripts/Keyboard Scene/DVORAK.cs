using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DVORAK : MonoBehaviour
{   
    // Declare
    string Input = null;
    int InputIndex = 0;
    string alpha;
    public Text text = null;

    public void CodeFunction(string words)
    {
        InputIndex++;
        Input = Input + words;
        text.text = Input;
        PlayerPrefs.SetString("input_words", Input);
        // Input is a string
        Debug.Log(Input);
    }

    public void Back()
    {
        InputIndex = 0;
        Input = "";
        text.text = Input;
    }

    public void Shift()
    {
        string newText = "";
        bool isAllCaps = true;

        foreach (char c in Input)
        {
            if (char.IsLetter(c))
            {
                if (char.IsLower(c))
                {
                    isAllCaps = false;
                }
            }
            else
            {
                newText += c;
            }
        }

        if (isAllCaps)
        {
            Input = Input.ToLower();
        }
        else
        {
            Input = Input.ToUpper();
        }

        text.text = Input;
    }


}
