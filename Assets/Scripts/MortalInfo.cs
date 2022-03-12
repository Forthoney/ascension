using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MortalInfo : MonoBehaviour
{
    [SerializeField] private int INITIAL_HEALTH = 100;
    private int health;
    private UnityEvent deathEvent;
    // Start is called before the first frame update
    
    void Start() {
        health = INITIAL_HEALTH;
    }

    public void TakeDamage(int amount) {
        health -= amount;
        if (health <= 0) {
            Death();
        }
    }

    void Death() {
        deathEvent.Invoke();
        Destroy(gameObject);    
    }
}
