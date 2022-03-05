using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public enum MoveState {
        DEFAULT = 0,
        WALL = 1, 
        //DASHING = 2,
    }

    public MoveState curState = MoveState.DEFAULT; 

    public float dashSpeed = 15.0f;
    public float wallDashSpeed = 10.0f;
    public float dashCooldown = 5.0f;

    public Vector3 curVelocity = new Vector3(0, 0, 0);


    public Rigidbody body;
    public CharacterController controller;


    
    private float curDashCooldown = 0;

    
    private void FixedUpdate()
    {
        if (curState == MoveState.DEFAULT)
        {
            controller.Move(curVelocity * Time.fixedDeltaTime);

            if (curDashCooldown >= 0)
            {
                curDashCooldown -= Time.fixedDeltaTime;
            }
        }
        else if (curState == MoveState.WALL)
        {
            // Nothing rn :)
        }
    }


    public void Dash(Vector3 direction)
    {
        ///body.AddForce(Camera.main.transform.forward * dashSpeed);
        
        if (curState == MoveState.DEFAULT)
        {
            if (curDashCooldown <= 0)
            {
                curVelocity = direction * dashSpeed;
                curDashCooldown = dashCooldown;
            }
            else
            {
                print("on cooldown !");
            }
        }
        else if (curState == MoveState.WALL)
        {
            curVelocity = direction * wallDashSpeed;

            curDashCooldown = 0; 
            curState = MoveState.DEFAULT;
        }
    }


    public void SetVelocity(Vector3 velocity)
    {
        curVelocity = velocity; 
    }

    public void addVelocity(Vector3 velocityAdd)
    {
        curVelocity += velocityAdd;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (curState == MoveState.DEFAULT)
        {
            curState = MoveState.WALL;
            curVelocity = Vector3.zero; 
        }
    }
}
