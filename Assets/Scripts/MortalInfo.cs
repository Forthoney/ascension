using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortalInfo : MonoBehaviour
{
    public int INITIAL_HEALTH = 100;
    int health;
    // Start is called before the first frame update
    
    void Start() {
        health = INITIAL_HEALTH;
    }

    void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0) {
            Death();
        }
    }

    void Death() {
        PlayDeathAnimation();
        Destroy(gameObject);    
    }

    //method to be used when a Death Animation is created
    void PlayDeathAnimation() {

    } 
}
