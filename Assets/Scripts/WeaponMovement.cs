using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    public float smooth;
    public float swayMultiplier;

    float mouseX; 
    float mouseY;
    Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        targetRotation = calcRotation();
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }

    Quaternion calcRotation() {
        mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        return rotationX * rotationY;
    }

}
