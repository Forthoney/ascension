using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShoot : MonoBehaviour
{
    public WeaponBehavior weapon;
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        if (this.IsAiming && this.weapon.CanShoot()) {
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
}
