using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlatforms : MonoBehaviour // Creates random platforms at set intervals
{
    public GameObject[] platforms; // Get platforms
    public GameObject coinString;
    public GameObject player;
    public BuildingGen build;
    int counter = 0;
    void Start()
    {
        float rand = Random.Range(0f,platforms.Length);
        for(int i = 0; i < platforms.Length; i++)
        {
            Instantiate(platforms[(int)rand],Vector3.right * (i * 9),gameObject.transform.rotation);
            rand = Random.Range(0f,platforms.Length);
        }
        counter += 36;
    }
    
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        if(playerPos.x > (counter / 2))
        {
            float rand = Random.Range(0f, 10f);
            if (rand > 8f)
            {
                build.Build(6, new Vector3(counter + 18, 0, 0));
                counter += 36;
            }
            else
            {
                Gen(new Vector3(counter + 3, 0, 0));
            }
        }
    }

    void Gen(Vector3 startPos)
    {
        float rand = Random.Range(0f, platforms.Length);
        for (int i = 0; i < platforms.Length; i++)
        {
            Instantiate(platforms[(int)rand],startPos + Vector3.right * (i * 9), gameObject.transform.rotation);
            bool coin = build.randomBool();
            if (coin)
            {
                Vector3 coinPos = new Vector3(startPos.x + i * 9, platforms[(int)rand].transform.localScale.y / 2 + 1, -0.1f);
                Instantiate(coinString, coinPos, transform.rotation);
            }
            rand = Random.Range(0f, platforms.Length);
        }
        
        counter += 36;
    }
}
