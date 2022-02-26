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

    public float dashSpeed = 20.0f;

    public Vector3 curVelocity = new Vector3(0, 0, 0);


    public Rigidbody body;
    public CharacterController controller; 

    
    private void FixedUpdate()
    {
        if (curState == MoveState.DEFAULT)
        {
            controller.Move(curVelocity * Time.fixedDeltaTime);
        }
        else if (curState == MoveState.WALL)
        {
            // Nothing rn :)
        }
    }


    public void Dash(Vector3 direction)
    {
        ///body.AddForce(Camera.main.transform.forward * dashSpeed);
        curVelocity = direction * dashSpeed;

        if (curState == MoveState.WALL)
        {
            curState = MoveState.DEFAULT;
        }
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
