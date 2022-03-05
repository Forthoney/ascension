using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintTriggerable : Triggerable
{

    public string printString = "NO STRING INPUTTED";

    override public void onTriggered()
    {
        print(printString);
    }
}
