using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour // Player movement
{
    public PlayerStats stats;
    public GameObject projectile;
    public Camera cam;
    public Transform shoot;
    public Transform pivot;
    public Animator animator;
    public SpriteRenderer sprite;
    Rigidbody rb;
    public int jumpHeight;
    public int speed;
    bool canJump = true;
    bool canWallJump = true;
    bool canShoot = true;
    float wallJumpDir;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal"); // Get left and right
        rb.AddForce(input*speed, 0, 0); // Move character
        if (input >= 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;  
        }

        if(input != 0)
        {
            animator.SetBool("isMoving", true);
            pivot.gameObject.SetActive(false);
        }
        else
        {
            animator.SetBool("isMoving", false);
            pivot.gameObject.SetActive(true);
        }

        Vector3 mousePos = cam.WorldToScreenPoint(transform.position);
        mousePos.z = 0;
        Debug.Log(Input.mousePosition);

        Vector3 aimDirection = Input.mousePosition - mousePos;
        float angle = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg;
        pivot.rotation = Quaternion.Euler(0f,0f,angle);
        Debug.Log(angle);

        if (Input.GetKey(KeyCode.Space) && canJump) // Check if can jump
        {
            rb.AddForce(0, jumpHeight, 0); // Jump
            canJump = false; // Disable jump
            pivot.gameObject.SetActive(false);
        }
        if(Input.GetKey(KeyCode.Space) && canWallJump)
        {
            rb.AddForce(wallJumpDir * (jumpHeight / 2), jumpHeight, 0);
            canWallJump = false;
        }
        if (Input.GetMouseButton(0)&&canShoot)
        {
            GameObject bullet = Instantiate(projectile, shoot.position, shoot.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * 1000);
            canShoot = false;
            Invoke("resetShoot", 0.4f);
        }
        if(transform.position.y < -15)
        {
            SceneManager.LoadScene("Main");
        }
        bool jump = !canJump & !canWallJump;
        animator.SetBool("isJumping",jump);
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
            sprite.color = Color.red;
            Invoke("coulorReset", 0.5f);
        }
    }

    void resetShoot()
    {
        canShoot = true;
        pivot.gameObject.SetActive(true);
    }

    void coulorReset()
    {
        sprite.color = Color.white;
    }
}
