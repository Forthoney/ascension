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
    private float zRotation;


    // For auto Rotation
    private Quaternion startRotate;
    private Quaternion endRotate;

    private float gotoXRotation;
    private float gotoYRotation;
    private float startXRotation;
    private float startYRotation;


    private float rotateTime;
    private float curRotateTime;
    private bool rotating = false;
    private int rotateDirection = 1; 


    // rotate around Right vector for up/down
    // rotate around up vector for right/left

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // Update is called once per frame
    void Update()
    {

        float zEdit = 0; 
        if (!rotating)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            yRotation += mouseX;
        }
        else
        {
            //cameraParent.localRotation *= Quaternion.Euler(0, 180 * rotateDirection * Time.deltaTime / rotateTime, 0);
            
            Quaternion eulerThing = Quaternion.Euler(0, 180 * rotateDirection * Time.deltaTime / rotateTime, 0);

            //Quaternion.ang*/

            xRotation += eulerThing.eulerAngles.x;
            yRotation += eulerThing.eulerAngles.y;
            
            zEdit = eulerThing.eulerAngles.z;

            curRotateTime += Time.deltaTime;

            //xRotation += (gotoXRotation - startXRotation) * Time.deltaTime / rotateTime;
            //yRotation += (gotoYRotation - startYRotation) * Time.deltaTime / rotateTime;

            //cameraParent.transform.forward += ((endRotate - startRotate) * Time.deltaTime);

            //if (Mathf.Abs(cameraParent.transform.rotation.eulerAngles.y - endRotate.eulerAngles.y) * Time.deltaTime <= Time.deltaTime * 2)
            if (curRotateTime > rotateTime)
            {
                rotating = false;
                
            }
        }

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraParent.localRotation = Quaternion.Euler(xRotation, yRotation, zEdit);
        playerHead.rotation = Quaternion.Euler(xRotation, yRotation, zEdit);
    }

    public Vector3 GetLookDirection()
    {
        return -(cameraParent.transform.forward).normalized;
    }


    public void StartRotate(int direction, float rotateTime)
    {

        //yRotationMove = Quaternion.AngleAxis(cameraParent.localRotation.eulerAngles.y, cameraParent.right);
        //xRotationMove = Quaternion.AngleAxis(cameraParent.localRotation.eulerAngles.x, cameraParent.up);


        endRotate = cameraParent.localRotation * Quaternion.Euler(0, 0, 0);
        startRotate = cameraParent.localRotation;

        /*gotoXRotation = ((xRotation + 180) % 360) - 180;
        gotoYRotation = ((yRotation + 180) % 360) - 180;
        startXRotation = xRotation;
        startYRotation = yRotation;*/

        //xRotation = gotoXRotation;
        //yRotation = gotoYRotation;

        rotateDirection = 1;
        curRotateTime = 0; 

        this.rotateTime = rotateTime;
        rotating = true; 

    }

}
