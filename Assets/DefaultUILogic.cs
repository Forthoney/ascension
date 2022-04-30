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
    public GameObject pauseUI;

    bool paused = false; 

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

    public void ShowDefaultScreen()
    {
        defaultUI.SetActive(true);
    }


    public void TogglePause()
    {

        if (paused)
        {
            UnPause();
        }
        else
        {
            Pause();
        }
    }


    public void Pause()
    {

        paused = true; 
        HideDefaultScreen();
        pauseUI.SetActive(true);

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    public void UnPause()
    {
        paused = false; 
        ShowDefaultScreen();
        pauseUI.SetActive(false);

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;

    }


    

    public void RevealDeathScreen()
    {
        HideDefaultScreen();
        deathUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
