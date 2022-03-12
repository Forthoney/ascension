using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActivateTrigger : Triggerable
{
    public override void onTriggered()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

}
