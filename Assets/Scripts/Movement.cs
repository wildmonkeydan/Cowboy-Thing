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
    }

    private void OnCollisionEnter(Collision collision) // Enable jump on collision
    {
        canJump = true;
        if(collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("Main");
        }
        if(collision.gameObject.tag == "bullet")
        {
            stats.healthChange(-20);
        }
    }
}
