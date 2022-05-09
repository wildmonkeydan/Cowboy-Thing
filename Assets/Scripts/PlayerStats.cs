using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour // Where player stats are defined and changed
{
    public int coins;
    public int health = 100;
    void Start()
    {
        
    }

    void Update()
    {
        if(health < 0)
        {
            SceneManager.LoadScene("Main");
        }
        Debug.Log(health);
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
