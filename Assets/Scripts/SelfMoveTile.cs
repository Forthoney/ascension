using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfMoveTile : MonoBehaviour
{

    public GameObject[] selfMoving;
    int current = 0;
    public float speed;
    float SMRadius = 1;

    // Update is called once per frame
    /*
     * In order to make this work must add this script to the gameObject you
     * want to move, and add empty gameobjects and make these empty objects 
     * the places you want to move to in the Serialized Field
     */
   
    void Update()
    {
        if (Vector3.Distance(selfMoving[current].transform.position,
            transform.position) < SMRadius) 
        {
            current++;
                if (current >= selfMoving.Length)
            {
                current = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position,
            selfMoving[current].transform.position, Time.deltaTime);
    }
}
