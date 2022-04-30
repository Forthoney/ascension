using UnityEngine;

namespace Enemy
{
    public class Shoot : MonoBehaviour
    {

        [SerializeField] private Animator shootAnimator;
        [SerializeField] private float shootRange = 30f;
        [SerializeField] private WeaponBehavior weapon;
        [SerializeField] private float duration = 2f;
        
        void Start()
        {
            shootAnimator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame

        void Update()
        {
            if (IsAiming() && weapon.CanShoot()) 
            {
                weapon.Shoot();
                Knockback(weapon.GetKnockback());
            }
        }

        private void ShootWeapon() {
            weapon.Shoot();
            shootAnimator.Play("Fire");
            Knockback(weapon.GetKnockback());
        }

        private void Knockback(float recoil) 
        {
            while (duration > 0) 
            {
                transform.position -= transform.forward * Time.deltaTime * recoil;
                duration -= Time.deltaTime;
            }
        }

        private bool IsAiming() 
        {
            return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, shootRange);
        }
    }
}