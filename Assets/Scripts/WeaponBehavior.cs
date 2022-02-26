using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public const float knockback = 10f;
    [SerializeField] GameObject projectile;
    float currentCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateCooldown();

        // This should be removed as shoot() will be called by the player/enemy.
        if (canShoot()) 
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shoot();
            }
        }
        
    }

    void shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        currentCooldown = 1f;
    }

    void updateCooldown() {
        if (!canShoot()) {
            currentCooldown = currentCooldown - Time.deltaTime;
            Debug.Log(currentCooldown);
        }
    }

    bool canShoot()
    {
        return (currentCooldown <= 0f);
    }

}
