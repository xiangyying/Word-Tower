using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + score;
    }

    private void onTriggerEnter2D(Collider2D marks)
    {
        if (marks.tag == "CreateYourTag")
        {
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}
