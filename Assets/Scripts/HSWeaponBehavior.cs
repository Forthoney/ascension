using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Watch video: https://www.youtube.com/watch?v=THnivyG0Mvo
public class HSWeaponBehavior : WeaponBehavior
{

    [Header("General Settings and Associations")]
    [SerializeField] private float range = 100f;
    [SerializeField] private Camera playerView;
    [SerializeField] private WeaponMovement weaponMovement;

    [Header("Screen Shake Settings")]
    [SerializeField] private ScreenShake shaker;
    [SerializeField] private float shakeDuration = 0.1f;
    [SerializeField] private float shakeIntensity = 0.1f;

    [Header("Weapon Spread Settings")]
    [SerializeField] private float maxAngleDeviation = 5f;

    


    public override void Shoot()
    {

        SetChargeValues();

        //weaponMovement.ApplyRecoil();
        ShootRay(playerView.transform);
        shaker.StartScreenShake(shakeDuration, shakeIntensity);
        ResetCooldown();

        PlayAnimation();

        SoundManager.Audio.Play(shootSound, 0.98f, 1.02f);
    }

    private void ShootRay(Transform fpsCamera)
    {
        RaycastHit hit;
        // Bit shift the index of the layer (2, the ignore raycast layer) to get a bit mask
        int layerMask = 1 << 2;
        // We want to cast rays again every collider that is NOT in layer 2. So we inverse the bitmap.
        layerMask = ~layerMask;

        Vector3 deviatedRay = GetDeviatedRay(fpsCamera.forward);

        OnShootVisuals();

        if (Physics.Raycast(fpsCamera.position, deviatedRay, out hit, range, layerMask)) //hit check
        {
            ApplyDamage(hit);
            OnHitVisuals(hit);
            if (hit.transform.tag == "Enemy") Debug.Log(Random.Range(1, 10000) + " shot an enemy");
        }

    }

    private Vector3 GetDeviatedRay(Vector3 forwardVector)
    {
        Vector3 deviatedRay = forwardVector;

        // Generates a value for the angle deviation from the normal forward vector (will determine r in polar coordinates).
        float deviation = Random.Range(0f, maxAngleDeviation);

        // Generates an angle between 0 and 360 degrees to determine where, on the deviation circle, the ray should be shot (theta in polar coordinates)
        float angle = Random.Range(0f, 360f);

        // Creates a Rotation around the y axis (Vector3.up) by "deviation" degrees and applies it to the forward vector.
        deviatedRay = Quaternion.AngleAxis(deviation, Vector3.up) * deviatedRay;

        // Creates a Rotation around the forward vector by "angle" degrees, and applies it to the deviated ray.
        deviatedRay = Quaternion.AngleAxis(angle, forwardVector) * deviatedRay;

        return deviatedRay;

    }

    private void ApplyDamage(RaycastHit hit)
    {
        Debug.Log(hit.transform.tag);
        if (hit.transform.CompareTag("Enemy"))
        {
            MortalInfo hitStats = hit.transform.GetComponent<MortalInfo>();
            hitStats.TakeDamage(this.damage);
        }
    }


    public override float GetKnockback()
    {
        return knockback;
    }
}
