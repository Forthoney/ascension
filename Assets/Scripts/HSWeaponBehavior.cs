using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSWeaponBehavior : MonoBehaviour
{
    float currentCooldown = 0f;
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;

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
            if (Input.GetButtonDown("Fire1"))
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
        RaycastHit hit;
        bool hasHit = Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range);
        if (hasHit) {
            // Simply prints the name of the hit object. Will later handle this and decide to create damage...
            Debug.Log(hit.transform.name);
        }
    }

    public bool CanShoot()
    {
        return (currentCooldown <= 0f);
    }
}
