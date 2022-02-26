using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private int health;
    private const float movementSpeed = 5f;
    public WeaponBehavior weapon;
    public Transform Player;
    
    // Start is called before the first frame update
    void Start()
    {
        this.health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        this.SetDestination(Player.position);
        if (this.IsAiming && this.weapon.canShoot()) {
            ShootWeapon();
        }
    }

    private void ShootWeapon() {
        this.weapon.shoot();
        this.knockback(this.weapon.knockback);
    }

    private void Knockback(float recoil) {
        float duration = 2f;

        while (duration > 0) {
            this.transform.position -= this.transform.forward * Time.deltaTime * recoil;
            duration -= Time.deltaTime;
        }
    }

    private bool IsAiming() {
        return true;
    }

    public void TakeDamage(int damage) {
        this.health -= damage;
    }
}
