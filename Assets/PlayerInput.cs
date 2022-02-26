using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public PlayerMovement movement;
    public MouseLook look; 



    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            movement.Dash(-look.GetLookDirection());
        }
    }
}
