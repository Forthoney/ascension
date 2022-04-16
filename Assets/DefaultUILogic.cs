using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultUILogic : MonoBehaviour
{

    public WeaponBehavior weapon;
    public Image chargeCircle;
    public float minCharge = 0.2f;

    public GameObject defaultUI;
    public GameObject deathUI;

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


    public void HideDefaultScreen()
    {
        defaultUI.SetActive(false);
    }

    public void RevealDeathScreen()
    {
        HideDefaultScreen();
        deathUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
