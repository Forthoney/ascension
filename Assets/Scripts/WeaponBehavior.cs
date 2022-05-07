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
    public Color color;
    public bool cancelVelocity;
    public AudioClip shootSound;

    public ChargeRow(float time, int dmg, float knock, Color col, bool cancel, AudioClip sound)
    {
        this.time = time;
        this.damage = dmg; 
        this.knockback = knock;
        this.color = col;
        this.cancelVelocity = cancel;
        this.shootSound = sound;
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

    public Color GetColor()
    {
        return color; 
    }

    public bool CancelVelocity()
    {
        return cancelVelocity;
    }

    public AudioClip GetSound()
    {
        return shootSound;
    }
}

public abstract class WeaponBehavior : MonoBehaviour
{

    public float defaultCooldown = 0.25f; 
    protected float currentCooldown;

    public Animation anim;


    [HideInInspector] public float knockback = 7.0f;
    [HideInInspector] protected int damage = 10;
    [HideInInspector] protected Color curChargeColor = Color.white; 


    // Charge stuff
    [SerializeField] private float maxChargeTime = 1.5f;
    // Array with seconds in, damage, and knockback level

    [SerializeField] private ChargeRow[] chargeLevels =  { new ChargeRow(0.25f, 50, 4, Color.green, false, null), new ChargeRow(0.75f, 100, 12, Color.yellow, false, null), new ChargeRow(1.25f, 200, 24, Color.red, true, null) };
    private float curChargeTime = 0;


    public bool chargeable = false; 
    private bool charging = false;
    public bool cancelCharge = false;


    // Bullet trail stuff
    [SerializeField] private ParticleSystem onShootParticles;
    [SerializeField] private ParticleSystem impactParticles;
    [SerializeField] private TrailRenderer bulletTrail;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private LayerMask hittable;

    [Header("Sound Settings")]
    [SerializeField] private bool playSound = false;
    [SerializeField] private AudioClip chargeSound;
    [SerializeField] private AudioSource source = null;
    // this one is overrided by charge stuff, unless there is no charging
    [SerializeField] protected AudioClip shootSound;




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

    public void PlayAnimation()
    {
        anim.Rewind();
        anim.Play();
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

            SoundManager.Audio.Play(chargeSound, 0.98f, 1.02f);
        }
    }

    // https://www.youtube.com/watch?v=cI3E7_f74MA
    public void OnShootVisuals()
    {
        onShootParticles.Play();
    }

    public void OnHitVisuals(RaycastHit hit)
    {
        TrailRenderer trail = Instantiate(bulletTrail, muzzle.transform.position, Quaternion.identity);

        StartCoroutine(SpawnTrail(trail, hit));
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, Hit.point, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        //Animator.SetBool("IsShooting", false);
        Trail.transform.position = Hit.point;
        Instantiate(impactParticles, Hit.point, Quaternion.LookRotation(Hit.normal));

        Destroy(Trail.gameObject, Trail.time);
    }


    public void UpdateCharge()
    {
        if (charging && curChargeTime < maxChargeTime)
        {
            curChargeTime = Mathf.Clamp(curChargeTime + Time.deltaTime, 0, maxChargeTime);


            curChargeColor = chargeLevels[GetChargeLevel()].GetColor();
        }
    }

    public void SetChargeValues()
    {
        // If chargeable, set values to the current respective charge level
        if (chargeable)
        {
            int chargeLevel = GetChargeLevel();

            Debug.Log("CHARGE LEVEL " + chargeLevel.ToString());

            damage = (int)chargeLevels[chargeLevel].GetDamage();
            knockback = chargeLevels[chargeLevel].GetKnockback();
            curChargeColor = chargeLevels[chargeLevel].GetColor();
            cancelCharge = chargeLevels[chargeLevel].CancelVelocity();
            shootSound = chargeLevels[chargeLevel].GetSound();

            Debug.Log("CHARGE LEVEL " + chargeLevel.ToString() + " dmg " + damage.ToString() + " knockback " + knockback.ToString());

            curChargeTime = 0;
            charging = false;
            
        }
        // If not chargeable, just get the charge value from the first one
        else
        {
            damage = (int)chargeLevels[0].GetDamage();
            knockback = chargeLevels[0].GetKnockback();
            cancelCharge = chargeLevels[0].CancelVelocity();
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

        return chargeLevels.Length - 1; 
    }


    public float GetCurrentCharge()
    {
        return curChargeTime;
    }

    public float GetMaxCharge()
    {
        return maxChargeTime;
    }

    public Color GetCurrentChargeColor()
    {
        return curChargeColor;
    }

    public bool CanShoot()
    {
        return (currentCooldown <= 0f);
    }

}
