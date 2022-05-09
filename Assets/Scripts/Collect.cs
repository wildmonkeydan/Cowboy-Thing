using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour // Allows for collection of collectables
{
    public PlayerStats stats; // Link to coin stats
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stats.coinChange(1);
            Destroy(gameObject);
        }
    }
}
