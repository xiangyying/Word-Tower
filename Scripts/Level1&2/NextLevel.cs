using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // private float startTime;

    [SerializeField] private AudioSource next;
    public Text level;
    public GameObject GO;
    public GameObject GO2;
    public Text timeText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            level.gameObject.SetActive(true);
            next.Play();
            GO.SetActive(false);
            GO2.SetActive(false);
            Invoke("movingNext", 3f); // Load After 3 seconds
        }
    }

    private void movingNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4); // This is the next level
    }

    
}
