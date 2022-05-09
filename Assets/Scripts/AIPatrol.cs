using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour // Controls AI to move side to side on a path
{
    public float walkSpeed;
    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;


    public Rigidbody rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1F, groundLayer);
        }
    }

    void Patrol()
    {
        if (mustTurn) Flip();
        rb.velocity = new Vector3(walkSpeed * Time.fixedDeltaTime, rb.velocity.y,0);
    }
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y,0);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
