using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finished : MonoBehaviour
{
    private float startTime;
    public Text FinishGame;
    public GameObject GO;
    public GameObject GO2;

    public Text timeText;

    [SerializeField] private AudioSource done;

    // game finished
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            FinishGame.gameObject.SetActive(true);
            done.Play();
            GO.SetActive(false);
            GO2.SetActive(false);
            SceneManager.LoadScene("End_Screen");
        }
    }
}
