using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public PlayerMovement movement;
    public MouseLook look;
    public WeaponBehavior weapon; 

    private void Update()
    {
        if (Input.GetButtonDown("Dash"))
        {
            movement.Dash(-look.GetLookDirection());
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (weapon.CanShoot())
            {
                // Fixes an issue with Screen Shake.
                Vector3 currentLookDirection = look.GetLookDirection();
                weapon.Shoot();
                movement.Knockback(currentLookDirection, 10);
            }
        }
    }
}
