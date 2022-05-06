using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int coins;
    public int health = 100;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void coinChange(int change)
    {
        coins += change;
    }

    public void healthChange(int change)
    {
        health += change;
        if(health > 100)
        {
            health = 100;
        }
    }
}
