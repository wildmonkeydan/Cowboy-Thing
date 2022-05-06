using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
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
    }
}
