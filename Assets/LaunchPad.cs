using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{

    public GameObject target;
    public float travelTime; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement playerMove = other.gameObject.GetComponent<PlayerMovement>();

            if (playerMove != null)
                // d = rt
            {
                playerMove.SetVelocity(((target.transform.position - playerMove.gameObject.transform.position) / travelTime));
            }


        }
    }
}
