using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public int damage = 10;
    public float projectileSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
        CheckCollision();
    }

    // Moves the projectile forward.
    void MoveProjectile()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
    }

    void CheckCollision()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(transform.position, transform.forward, out hit, projectileSpeed);
        if (hasHit)
        {
            //Debug.Log(hit.transform.name);
            // If the projectile hits a player, call its TakeDamage method.
            if (hit.transform.name == "Player")
            {
                MortalInfo hitStats = hit.transform.GetComponent<MortalInfo>();
                hitStats.TakeDamage(this.damage);
            }
            else
            {
                // If the projectile hits something else than a player, then destroy the game object.
                Object.Destroy(this.gameObject);
            }
        }
    }
}
