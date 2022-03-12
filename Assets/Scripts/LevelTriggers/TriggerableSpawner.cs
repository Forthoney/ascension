using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerableSpawner : Triggerable
{

    public GameObject toSpawn; 

    public override void onTriggered()
    {
        GameObject ob = Instantiate(toSpawn);
        ob.transform.parent = null; 
    }

}
