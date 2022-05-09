using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlatforms : MonoBehaviour // Creates random platforms at set intervals
{
    public GameObject[] platforms; // Get platforms
    void Start()
    {
        float rand = Random.Range(0f,platforms.Length);
        for(int i = 0; i < platforms.Length; i++)
        {
            Instantiate(platforms[(int)rand],Vector3.right * (i*3),gameObject.transform.rotation);
            rand = Random.Range(0f,platforms.Length);
        }
    }
    
    void Update()
    {
            
    }
}
