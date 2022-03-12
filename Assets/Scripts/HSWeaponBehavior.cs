using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Watch video: https://www.youtube.com/watch?v=THnivyG0Mvo
public class HSWeaponBehavior : WeaponBehavior
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float range = 100f;
    [SerializeField] private Camera playerView;
    [SerializeField] private WeaponMovement weaponMovement;

    [SerializeField] private ScreenShake shaker;
    [SerializeField] private float shakeDuration = 0.1f;
    [SerializeField] private float shakeIntensity = 0.1f;

    public float knockback = 7.0f; 

    public override void Shoot()
    {
        //weaponMovement.ApplyRecoil();
        ShootRay(playerView.transform);
        shaker.StartScreenShake(shakeDuration, shakeIntensity);
        ResetCooldown();
    }

    private void ShootRay(Transform fpsCamera)
    {
        RaycastHit hit;
        // Bit shift the index of the layer (2, the ignore raycast layer) to get a bit mask
        int layerMask = 1 << 2;
        // We want to cast rays again every collider that is NOT in layer 2. So we inverse the bitmap.
        layerMask = ~layerMask;
        if (Physics.Raycast(fpsCamera.position, fpsCamera.forward, out hit, range, layerMask)) //hit check
        {
            ApplyDamage(hit);
        }
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
