using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    private Animator anim;
    public Transform respawnPoint;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerAlive();
            other.gameObject.transform.position = respawnPoint.position;

        }
    }

    private void PlayerAlive()
    {
        anim.SetTrigger("revive");
    }
}
