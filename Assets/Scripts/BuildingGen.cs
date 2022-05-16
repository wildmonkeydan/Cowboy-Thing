using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGen : MonoBehaviour // Random gen a building using segments
{
    public GameObject[] buildingParts;
    public GameObject[] enemies;
    void Start()
    {
        Build(4,Vector3.left*5);
    }

    void Update()
    {
        
    }

    public void Build(int size, Vector3 origin) // Builds the building when called, using the size as a reference for how many floors and the origin for where the ground floor is.
    {
        for(int i = 0; i < size; i++)
        {
            Instantiate(buildingParts[Random.Range(0,buildingParts.Length)],origin,transform.rotation);
            if (randomBool())
            {
                createEnemy(origin + Vector3.left*3);
            }
            origin += Vector3.up * 5;
        }
    }

    public bool randomBool() // Returns a random bool 
    {
        return (Random.value > 0.5f);
    }

    void createEnemy(Vector3 pos) // Creates a random patrolling enemy on the floor that is currently being made or anywhere specified
    {
        Instantiate(enemies[Random.Range(0,enemies.Length)],pos,transform.rotation);
    }
}
