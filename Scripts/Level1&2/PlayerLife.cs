using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    [SerializeField] private AudioSource dieEffect;
    [SerializeField] private AudioSource lifeEffect;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Traps"))
        {
            PlayerDeath();
            if (collision.gameObject.name == "Player")
            {
                PlayerAlive();
            }
        }
    }

    private void PlayerDeath()
    {
        rb.bodyType = RigidbodyType2D.Static; // stop the player
        anim.SetTrigger("die");
        // Play sound effect
        dieEffect.Play();
    }


    private void PlayerAlive()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // start the player
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
