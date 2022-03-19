using UnityEngine;

namespace Enemy
{
    public class Shoot : MonoBehaviour
    {
        public float shootRange = 30f;
    
        public WeaponBehavior weapon;

        // Update is called once per frame
        void Update()
        {
            if (IsAiming() && weapon.CanShoot()) {
                ShootWeapon();
            }
        }

        private void ShootWeapon() {
            weapon.Shoot();
            Knockback(weapon.GetKnockback());
        }

        private void Knockback(float recoil) {
            float duration = 2f;

            while (duration > 0) {
                transform.position -= transform.forward * Time.deltaTime * recoil;
                duration -= Time.deltaTime;
            }
        }

        private bool IsAiming() {
            return Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, shootRange);
        }
    }
}
