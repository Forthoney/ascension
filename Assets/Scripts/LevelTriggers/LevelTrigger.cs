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
    

    public void ActivateTrigger()
    {
        foreach (Triggerable activate in toActivate)
        {
            activate.onTriggered();
        }
    }
}
