using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultUILogic : MonoBehaviour
{
    [SerializeField] private WeaponBehavior weapon;
    [SerializeField] private Image chargeCircle;
    [SerializeField] private float minCharge = 0.2f;

    [SerializeField] private GameObject defaultUI;
    [SerializeField] private GameObject deathUI;
    [SerializeField] private GameObject pauseUI;

    // TODO: put this in a separate script
    public Image hitTint;
    public Color tint;
    public MortalInfo info;

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
        
        // TODO: Tweening!!
        float healthPercent = (float) info.GetHealth() / (float) info.GetMaxHealth();
        tint.a = 1 - (0.6f + (0.4f * healthPercent));
        hitTint.color = tint;
    }

    public void TogglePause()
    {
        if (deathUI.activeSelf) return;
        if (paused)
        {
            defaultUI.SetActive(true);
            UnpauseGame();
        }
        else
        {
            defaultUI.SetActive(false);
            PauseGame();
        }
    }
    
    private void PauseGame()
    {
        paused = true; 
        pauseUI.SetActive(true);

        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    private void UnpauseGame()
    {
        paused = false; 
        pauseUI.SetActive(false);

        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void RevealDeathScreen()
    {
        defaultUI.SetActive(false);
        Time.timeScale = 0.001f;
        
        deathUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
