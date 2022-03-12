using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    [Header("Movement Sway Settings")]
    [SerializeField] private float smoothSway;
    [SerializeField] private float swayMultiplier;
    [Header("Recoil Settings")]
    [SerializeField] private float magnitude;
    [SerializeField] private float recoilPeriod;
    
    void Update()
    {
        transform.localRotation = SwayMovement(transform.localRotation);
    }

    private Quaternion SwayMovement(Quaternion localRotation)
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        return Quaternion.Slerp(localRotation, rotationX * rotationY, smoothSway * Time.deltaTime);
    }
    public void ApplyRecoil()
    {
        Quaternion recoilRotation = Quaternion.AngleAxis(magnitude, Vector3.up);
        float elapsedTime = 0f;
        while (elapsedTime < recoilPeriod) 
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, recoilRotation, recoilPeriod - elapsedTime);
            elapsedTime += Time.deltaTime;
        }
    }
}
