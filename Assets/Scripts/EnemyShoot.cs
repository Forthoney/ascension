using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float shootRange = 30f;
    
    public WeaponBehavior weapon;

    // Update is called once per frame
    void Update()
    {
        if (this.IsAiming() && weapon.CanShoot()) {
            ShootWeapon();
        }
    }

    void ShootWeapon() {
        weapon.Shoot();
        this.Knockback(weapon.GetKnockback());
    }

    void Knockback(float recoil) {
        float duration = 2f;

        while (duration > 0) {
            transform.position -= transform.forward * Time.deltaTime * recoil;
            duration -= Time.deltaTime;
        }
    }

    bool IsAiming() {
        return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, shootRange);
    }
}
