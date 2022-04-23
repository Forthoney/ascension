using UnityEngine;

namespace Enemy
{
    public class Shoot : MonoBehaviour
    {
        public float shootRange = 30f;
    
        public WeaponBehavior weapon;

        [SerializeField] private Animator shootAnimator;
        private bool testVal;

        void Start()
        {
            shootAnimator = GetComponentInChildren<Animator>();
            testVal = true;
        }

        // Update is called once per frame

        void Update()
        {
            if (IsAiming() && weapon.CanShoot()) {
                ShootWeapon();
            }
        }

        private void ShootWeapon() {
            weapon.Shoot();
            Debug.Log("shootweapon called.");
            //Debug.Log(shootAnimator);
            shootAnimator.Play("Fire");
            //testVal = false;
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
