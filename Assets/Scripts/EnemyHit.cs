using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public bool isHit;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "playerbullet")
        {
            animator.SetBool("isDead", true);
            Invoke("die", 0.5f);
        }
        if (isHit)
        {

        }
    }

    void die()
    {
        Destroy(gameObject);
    }
}
