using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public Rigidbody projectile;
    public float knockback = 10f;
    float bulletSpeed = 10f;

    float currentCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown <= 0f)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shoot();
                currentCooldown = 1f;
            }
        }
        else
        {
            currentCooldown = currentCooldown - Time.deltaTime;
            Debug.Log(currentCooldown);
        }
    }

    void shoot()
    {
        Rigidbody newBullet = Instantiate(projectile, transform.position, transform.rotation);
        newBullet.velocity = transform.TransformDirection(Vector3.forward * bulletSpeed);
    }

    bool canShoot()
    {
        return true;
    }

}
