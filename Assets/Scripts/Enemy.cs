using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectile;
    public PlayerStats stats;
    bool canShoot = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canShoot)
        {
            GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
            bullet.transform.LookAt(GameObject.Find("Player").transform);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * 2);
            canShoot = false;
            Invoke("resetShoot", 0.4f);
        }
    }

    void resetShoot()
    {
        canShoot = true;
    }
}
