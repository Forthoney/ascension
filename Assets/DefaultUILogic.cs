using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultUILogic : MonoBehaviour
{

    public WeaponBehavior weapon;
    public Image chargeCircle;
    public float minCharge = 0.2f; 

    // Update is called once per frame
    void Update()
    {
        float chargeAmtReal = weapon.GetCurrentCharge() / weapon.GetMaxCharge();
        float chargeAmtVisual = (weapon.GetCurrentCharge() - minCharge) / (weapon.GetMaxCharge() - minCharge);

        if (chargeAmtReal > minCharge) {
            chargeCircle.fillAmount = chargeAmtVisual;
            chargeCircle.color = weapon.GetCurrentChargeColor();
        }
        else
        {
            chargeCircle.fillAmount = 0; 
        }
    }
}
