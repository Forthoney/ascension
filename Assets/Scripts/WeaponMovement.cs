using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovement : MonoBehaviour
{
    [Header("Movement Sway Settings")]
    [SerializeField] private float smoothSway;
    [SerializeField] private float swayMultiplier;
    [Header("Recoil Settings")]
    [SerializeField] private Animation recoilAnimation;
    
    void Update()
    {
        transform.localRotation = SwayMovement();
    }

    private Quaternion SwayMovement()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        return Quaternion.Slerp(transform.localRotation, rotationX * rotationY, smoothSway * Time.deltaTime);
    }

    public void ApplyRecoil()
    {
        recoilAnimation.Play();
    }
    // public void ApplyRecoil()
    // {
    //     Quaternion recoverRotation = Quaternion.AngleAxis(magnitude, Vector3.down);
    //
    //     bool isRecoiling = true;
    //     
    //     while (isRecoiling)
    //     {
    //         isRecoiling = Recoil(Quaternion.AngleAxis(magnitude, Vector3.up), recoilPeriod);
    //     }
    //     Recoil(Quaternion.AngleAxis(magnitude, Vector3.down), recoverPeriod);
    // }
    //
    // private bool Recoil(Quaternion rotation, float period)
    // {
    //     float elapsedTime = 0f;
    //     while (elapsedTime < recoilPeriod) 
    //     {
    //         transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, period - elapsedTime);
    //         elapsedTime += Time.deltaTime;
    //     }
    //
    //     return false;
    // }
}
