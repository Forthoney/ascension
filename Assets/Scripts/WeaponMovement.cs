using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    [Header("Movement Sway Settings")]
    [SerializeField] private float smooth;
    [SerializeField] private float swayMultiplier;
    float mouseX, mouseY;
    Quaternion targetRotation;

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = MovementSway(transform.localRotation);
    }

    Quaternion MovementSway(Quaternion localRotation)
    {
        mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);
        return Quaternion.Slerp(localRotation, rotationX * rotationY, smooth * Time.deltaTime);
    }
}
