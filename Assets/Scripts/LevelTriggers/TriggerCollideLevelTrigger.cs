using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollideLevelTrigger : LevelTrigger
{

    private void OnTriggerEnter(Collider other)
    {
        ActivateTrigger();
    }
}
