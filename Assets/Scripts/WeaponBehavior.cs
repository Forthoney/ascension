using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    private float knockback = 10f;
    [SerializeField] GameObject projectile;
    private float currentCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCooldown();

        // This should be removed as Shoot() will be called by the player/enemy.
        if (CanShoot()) 
        {
            //if (Input.GetButtonDown("Fire1"))
            if (false)
            {
                Shoot();
            }
        }
        
    }

    void UpdateCooldown() {
        if (!CanShoot()) {
            currentCooldown = currentCooldown - Time.deltaTime;
            Debug.Log(currentCooldown);
        }
    }

    public void Shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        currentCooldown = 1f;
    }

    public bool CanShoot()
    {
        return (currentCooldown <= 0f);
    }

    public float getKnockback() {
        return knockback;
    }
}
