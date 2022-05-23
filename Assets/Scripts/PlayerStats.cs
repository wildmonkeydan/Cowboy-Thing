using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour // Where player stats are defined and changed
{
    public int coins;
    public int health = 100;
    public Text[] counters;
    void Start()
    {
        
    }

    void Update()
    {
        if(health < 0)
        {
            SceneManager.LoadScene("Main");
        }

        counters[0].text = coins.ToString();
        counters[1].text = health.ToString();
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
