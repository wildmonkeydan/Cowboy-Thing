using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour // Player movement
{
    public PlayerStats stats;
    Rigidbody rb;
    public int jumpHeight;
    public int speed;
    bool canJump = true;
    bool canWallJump = true;
    float wallJumpDir;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal"); // Get left and right
        rb.AddForce(input*speed, 0, 0); // Move character

        if (Input.GetKey(KeyCode.Space) && canJump) // Check if can jump
        {
            rb.AddForce(0, jumpHeight, 0); // Jump
            canJump = false; // Disable jump
        }
        if(Input.GetKey(KeyCode.Space) && canWallJump)
        {
            rb.AddForce(wallJumpDir * (jumpHeight / 2), jumpHeight, 0);
            canWallJump = false;
        }
        if(transform.position.y < -15)
        {
            SceneManager.LoadScene("Main");
        }
    }

    private void OnCollisionEnter(Collision collision) // Enable jump on collision
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            canJump = true;
        }
        if(collision.contacts[0].normal == Vector3.right || collision.contacts[0].normal == Vector3.left)
        {
            canWallJump = true;
            wallJumpDir = collision.contacts[0].normal.x;
        }
        if(collision.gameObject.tag == "bullet")
        {
            stats.healthChange(-20);
        }
    }
}
