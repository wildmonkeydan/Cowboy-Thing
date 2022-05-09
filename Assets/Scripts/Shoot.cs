using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public PlayerStats stats;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stats.healthChange(-10);
        }
        Invoke("end",2);
    }

    void end()
    {
        Destroy(gameObject);
    }
}
