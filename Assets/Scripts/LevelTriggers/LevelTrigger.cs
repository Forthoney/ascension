using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Triggerable : MonoBehaviour
{
    public abstract void onTriggered();
}

public class LevelTrigger : MonoBehaviour
{
    
    public Triggerable[] toActivate;
    public bool oneShot = true; 
    private int timesUsed = 0; 
    

    public void ActivateTrigger()
    {

        if (!oneShot || timesUsed <= 0)
        {
            foreach (Triggerable activate in toActivate)
            {
                activate.onTriggered();
            }
            timesUsed++; 
        }
    }
}
