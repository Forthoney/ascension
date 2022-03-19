using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] private PlayerMovement movement;
    [SerializeField] private Transform cameraParent;
    [SerializeField] private WeaponBehavior weapon; 

    private void Update()
    {
        if (Input.GetButtonDown("Dash"))
        {
            movement.Dash(cameraParent.forward);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (!weapon.chargeable && weapon.CanShoot())
            {
                weapon.Shoot();
                movement.Knockback(-cameraParent.forward, weapon.GetKnockback());
            }
            else if (weapon.chargeable)
            {
                weapon.StartCharge();
            }

        }
        else if (Input.GetButtonUp("Fire1"))
        {
            if (weapon.chargeable)
            {
                weapon.Shoot();
                movement.Knockback(-cameraParent.forward, weapon.GetKnockback());
            }
        }
    }
}
