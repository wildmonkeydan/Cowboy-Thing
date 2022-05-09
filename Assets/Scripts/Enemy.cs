using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;
    public PlayerStats stats;
    public Transform shoot;
    bool canShoot = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (canShoot && other.tag == "Player")
        {
            GameObject bullet = Instantiate(projectile, shoot.position, shoot.rotation);
            bullet.transform.LookAt(GameObject.Find("Player").transform);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * 1000);
            canShoot = false;
            Invoke("resetShoot", 0.4f);
        }
    }

    void resetShoot()
    {
        canShoot = true;
    }
}
