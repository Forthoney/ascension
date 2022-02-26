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

        }
    }
}
