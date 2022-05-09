using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGen : MonoBehaviour // Random gen a building using segments
{
    public GameObject[] buildingParts;
    void Start()
    {
        Build(2,Vector3.left*5);
    }

    void Update()
    {
        
    }

    void Build(int size, Vector3 origin) // Builds the building when called, using the size as a reference for how many floors and the origin for where the ground floor is.
    {
        for(int i = 0; i < size; i++)
        {
            Instantiate(buildingParts[Random.Range(0,buildingParts.Length)],origin,transform.rotation);
            origin += Vector3.up * 5;
        }
    }
}
