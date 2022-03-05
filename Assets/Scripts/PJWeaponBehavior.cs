using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJWeaponBehavior : WeaponBehavior
{
    public GameObject projectile;
    public override void Shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
        ResetCooldown();
    }

    public override float GetKnockback()
    {
        return 0f;
    }

}
