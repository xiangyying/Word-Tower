using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Declare
    public GameObject Canvas;

    private bool isMoving;

    private Rigidbody2D rb2;
    private SpriteRenderer sr;
    private Animator anim;
    private BoxCollider2D bc2;
    [SerializeField] private LayerMask groundLayer;
    

    private float dirX;
    [SerializeField]private float move = 3f;
    [SerializeField]private float jumps = 1.2f;

    private enum States {idle, running, jumping, falling};     

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Start");
        rb2 = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        bc2 = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
        if (!Canvas.activeSelf)
        {
            Canvas.SetActive(true);
            Time.timeScale = 0f;
            // Cursor.visible = true;
        }
        else
        {
            Canvas.SetActive(false);
            Time.timeScale = 1f;
            // Cursor.visible = false;
        }
    }

    UpdateAnimationState();
    }

    public void MoveLeft()
    {
        dirX = -1;
        isMoving = true;
        // rb2.velocity = new Vector2(dirX * move, rb2.velocity.y);
    }

    public void MoveRight()
    {
        dirX = 1;
        isMoving = true;
        // rb2.velocity = new Vector2(dirX * move, rb2.velocity.y);
    }

    public void StopMoving()
    {
        dirX = 0;
        isMoving = false;
        rb2.velocity = new Vector2(dirX * move, rb2.velocity.y);
    }

    private void FixedUpdate()
    {
    if (isMoving)
    {
        rb2.velocity = new Vector2(dirX * move, rb2.velocity.y);
    }
    }

    // isMoving
    public bool IsMoving()
    {
        return isMoving;
    }

    public void Jump()
    {
        if (isGrounded())
        {
            rb2.velocity = new Vector2(rb2.velocity.x, jumps);
        }
    }

    public void Resume()
    {
        Canvas.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    private void UpdateAnimationState()
    {
        States state;

        // Toggle running and idle animation
        if (dirX > 0)
        {
            state = States.running;
            sr.flipX = false;
        }
        else if (dirX < 0)
        {
            state = States.running;
            sr.flipX = true;
        }
        else 
        {
            state = States.idle;
        }

        if (rb2.velocity.y > .1f)
        {
            state = States.jumping;
        }
        else if (rb2.velocity.y < -.1f)
        {
            state = States.falling;
        }
        anim.SetInteger("states", (int)state);
    }
    private bool isGrounded()
    {
        // Create a box around the player and check if it is colliding with the ground
        return Physics2D.BoxCast(bc2.bounds.center, bc2.bounds.size, 0f, Vector2.down, .1f, groundLayer);

    }
}
