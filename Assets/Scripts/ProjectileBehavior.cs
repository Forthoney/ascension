using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    float projectileSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveProjectile();
    }

    // Moves the projectile forward.
    void moveProjectile() {
        this.transform.position += this.transform.forward * Time.deltaTime * projectileSpeed;
    }
}
