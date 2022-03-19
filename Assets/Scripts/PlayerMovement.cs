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

    public float wallHitCooldown = 0.2f;
    private float curWallHitCooldown = 0.0f;


    private void FixedUpdate()
    {


        controller.Move(curVelocity * Time.fixedDeltaTime);

        if (curDashCooldown >= 0)
        {
            curDashCooldown -= Time.fixedDeltaTime;
        }

        curWallHitCooldown -= Time.fixedDeltaTime; 
        
    }


    public void Dash(Vector3 direction)
    {
        ///body.AddForce(Camera.main.transform.forward * dashSpeed);

        if (curDashCooldown <= 0 && curState == MoveState.DEFAULT)
        {
            curVelocity = direction * dashSpeed;
            curDashCooldown = dashCooldown;
        }
        else
        {
            print("on cooldown !");
        }
        
        if (curState == MoveState.WALL)
        {
            curVelocity = direction * wallDashSpeed;

            curDashCooldown = 0; 
            curState = MoveState.DEFAULT;
            curWallHitCooldown = wallHitCooldown;
        }
    }


    public void SetVelocity(Vector3 velocity)
    {
        curVelocity = velocity;

        if (curState == MoveState.WALL)
        {
            curWallHitCooldown = wallHitCooldown;
            curState = MoveState.DEFAULT;
        }
    }

    public Vector3 GetVelocity() {
        return curVelocity;
    }

    public void Knockback(Vector3 direction, float knockbackAmount)
    {
        curVelocity += direction * knockbackAmount;

        if (curState == MoveState.WALL)
        {
            curWallHitCooldown = wallHitCooldown;
            curState = MoveState.DEFAULT;
        }
                
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        bool specialWall = false;

        if (hit.gameObject.tag == "SpecialWall") {
            SpecialWallBehavior wallBehavior = hit.gameObject.GetComponent<SpecialWallBehavior>();
            specialWall = wallBehavior.StartWallCollisionBehavior(this.gameObject, hit.normal);
        }
        
        if (Vector3.Angle(hit.normal, -curVelocity.normalized) <= 90 && curWallHitCooldown <= 0f && !specialWall)
        {
            curVelocity = Vector3.zero;
            curState = MoveState.WALL;      
            Debug.Log(curVelocity.ToString());
        }
        
        

        

        

        //if (curState == MoveState.DEFAULT && curWallHitCooldown <= 0f)
        //{
           // curState = MoveState.WALL;
          //  curVelocity = Vector3.zero;
       // }
    }
}
