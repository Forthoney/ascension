using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MortalInfo : MonoBehaviour
{
    [SerializeField] private int INITIAL_HEALTH = 100;
    [SerializeField] private int maxHealth = 100;
    private int health;
    public UnityEvent deathEvent;
    public UnityEvent onHitEvent; 
    // Start is called before the first frame update
    



    void Start() {
        health = INITIAL_HEALTH;
    }

    public int GetHealth()
    {
        return health; 
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void TakeDamage(int amount) {
        health -= amount;
        //Debug.Log("current player health: " + health);
        if (health <= 0) {
            Death();
        }
        onHitEvent.Invoke();
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth); 
    }

    void Death() {
        deathEvent.Invoke();
    }

    public void DefaultDeath()
    {
        Destroy(gameObject);
    }

    public void PauseGameDeath()
    {
        Time.timeScale = 0;
    }
}
