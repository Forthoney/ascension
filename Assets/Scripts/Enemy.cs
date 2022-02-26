using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health;
    private const float movementSpeed = 5f;
    private WeaponBehavior weapon;
    
    // Start is called before the first frame update
    void Start()
    {
        this.health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        this.movePattern();
        this.aimAtPlayer();
        if (this.isAiming && this.weapon.canShoot()) {
            this.shootWeapon();
        }
    }

    private void shootWeapon() {
        this.weapon.shoot();
        this.knockback(this.weapon.recoil);
    }

    private void knockback(float recoil) {
        float duration = 2f;

        while (duration > 0) {
            this.transform.position -= this.transform.forward * Time.deltaTime * recoil;
            duration -= Time.deltaTime;
        }
    }

    private bool isAiming() {
    }

    private void movePattern() {
        
    }

}
