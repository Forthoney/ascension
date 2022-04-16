using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public int damage = 10;
    public float projectileSpeed = 10f;

    
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * projectileSpeed;
        CheckCollision();
    }
    private void CheckCollision()
    {
        if (!Physics.Raycast(transform.position, transform.forward, out var hit,
                projectileSpeed * Time.deltaTime)) return;
        
        if (hit.transform.gameObject.CompareTag("Player"))
        {
            hit.transform.GetComponent<MortalInfo>().TakeDamage(this.damage);
        }
        Destroy(gameObject);
    }
}
