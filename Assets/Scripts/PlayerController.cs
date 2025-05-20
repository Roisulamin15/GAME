using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 playerEarlyPosition;
    public float speed = 8;
    public float jumpForce = 20;

    private Rigidbody2D rb;
    private bool isGrounded = true;
    public bool gameOver = false;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        playerEarlyPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // ambil komponen SpriteRenderer
    }

    void Update()
    {
        if (!gameOver)
        {
            MoveHorizontal();
            MoveJump();
        }
    }

    void MoveHorizontal()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float movement = horizontalInput * Time.deltaTime * speed;
        float newPositionX = transform.position.x + movement;

        transform.position = new Vector3(newPositionX, transform.position.y, 0);

        // Flip player saat bergerak ke kiri atau kanan
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false; // hadap kanan
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true; // hadap kiri
        }
    }

    void MoveJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // Uncomment jika ingin game over saat kena musuh
        // if (collision.gameObject.CompareTag("Enemy"))
        // {
        //     Debug.Log("Game over");
        //     gameOver = true;
        // }
    }
}
