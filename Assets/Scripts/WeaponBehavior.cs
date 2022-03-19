using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// https://answers.unity.com/questions/1017593/initializing-2d-array-via-inspector.html 
// Required for multidimensional arrays in inspector
[System.Serializable]
public class ChargeRow
{
    public int damage;
    public float time;
    public float knockback; 

    public ChargeRow(float time, int dmg, float knock)
    {
        this.time = time;
        this.damage = dmg; 
        this.knockback = knock; 
    }


    public float GetTime()
    {
        return time; 
    }

    public float GetDamage()
    {
        return damage; 
    }

    public float GetKnockback()
    {
        return knockback; 
    }
}

public abstract class WeaponBehavior : MonoBehaviour
{

    public float defaultCooldown = 0.25f; 
    protected float currentCooldown;


    public float knockback = 7.0f;
    [SerializeField] protected int damage = 10;


    // Charge stuff
    [SerializeField] private float maxChargeTime = 1.5f;
    // Array with seconds in, damage, and knockback level

    [SerializeField] private ChargeRow[] chargeLevels =  { new ChargeRow(0.25f, 50, 4), new ChargeRow(0.75f, 100, 12), new ChargeRow(1.25f, 200, 24) };
    private float curChargeTime = 0;


    public bool chargeable = false; 
    private bool charging = false;

    


    // Start is called before the first frame update
    void Start()
    {
        currentCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharge();
        UpdateCooldown();
    }

    void UpdateCooldown()
    {
        if (!CanShoot())
        {
            currentCooldown = currentCooldown - Time.deltaTime;
        }
    }

    protected void ResetCooldown()
    {
        currentCooldown = defaultCooldown;
    }

    public abstract void Shoot();
    public abstract float GetKnockback();


    public void StartCharge()
    {
        if (chargeable)
        {
            charging = true;
        }
    }

    public void UpdateCharge()
    {
        if (charging && curChargeTime < maxChargeTime)
        {
            curChargeTime = Mathf.Clamp(curChargeTime + Time.deltaTime, 0, maxChargeTime);
        }
    }

    public void SetChargeValues()
    {
        if (chargeable)
        {
            int chargeLevel = GetChargeLevel();

            Debug.Log("CHARGE LEVEL " + chargeLevel.ToString());

            damage = (int)chargeLevels[chargeLevel].GetDamage();
            knockback = chargeLevels[chargeLevel].GetKnockback();

            Debug.Log("CHARGE LEVEL " + chargeLevel.ToString() + " dmg " + damage.ToString() + " knockback " + knockback.ToString());

            curChargeTime = 0;
            charging = false;
        }
    }

    public int GetChargeLevel()
    {
        for (int i = 0; i < chargeLevels.Length; i++)
        {
            if (chargeLevels[i].GetTime() > curChargeTime)
            {
                return i; 
            }
        }

        return 0; 
    }


    public float GetCurrentCharge()
    {
        return curChargeTime;
    }

    public float GetMaxCharge()
    {
        return maxChargeTime;
    }

    public bool CanShoot()
    {
        return (currentCooldown <= 0f);
    }
}
