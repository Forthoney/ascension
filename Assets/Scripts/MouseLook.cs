using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// https://www.youtube.com/watch?v=_QajrabyTJc
public class MouseLook : MonoBehaviour
{
    [SerializeField] private Transform cameraParent;
    [SerializeField] private Transform playerHead;
    
    [SerializeField] private float mouseSensitivity = 100f;
    
    private float xRotation;
    private float yRotation;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;
        
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraParent.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        playerHead.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    public Vector3 GetLookDirection()
    {
        return -(cameraParent.transform.forward).normalized;
    }
}
