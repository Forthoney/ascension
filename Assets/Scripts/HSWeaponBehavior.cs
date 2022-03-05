using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Watch video: https://www.youtube.com/watch?v=THnivyG0Mvo
public class HSWeaponBehavior : MonoBehaviour
{
    float currentCooldown = 0f;
    public int damage = 10;
    public float range = 100f;
    public Camera fpsCam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCooldown();
    }

    void UpdateCooldown() {
        if (!CanShoot()) {
            currentCooldown = currentCooldown - Time.deltaTime;
        }
    }

    public void Shoot()
    {
        // Bit shift the index of the layer (2, the ignore raycast layer) to get a bit mask
        int layerMask = 1 << 2;

        // We want to cast rays again every collider that is NOT in layer 2. So we inverse the bitmap.
        layerMask = ~layerMask;

        RaycastHit hit;
        bool hasHit = Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, layerMask);

        if (hasHit) {
            Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "Enemy") {
                MortalInfo hitStats = hit.transform.GetComponent<MortalInfo>();
                hitStats.TakeDamage(this.damage);
            }
        }

        currentCooldown = 1f;
    }

    public bool CanShoot()
    {
        return (currentCooldown <= 0f);
    }
}
