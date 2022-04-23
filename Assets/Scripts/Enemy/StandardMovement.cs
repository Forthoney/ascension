namespace Enemy
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class StandardMovement : Movement
    {
        [SerializeField] private float changeBehaviorProximity = 15f;
        private Movement currentMovement;
        private AggressiveMovement aggressiveMovement;
        private RandomMovement randomMovement;

        private void Start()
        {
            aggressiveMovement = gameObject.GetComponent<AggressiveMovement>();
            randomMovement = gameObject.GetComponent<RandomMovement>();
        }

        void Update()
        {
            if (DistanceToTarget() > changeBehaviorProximity)
            {
                if (currentMovement != aggressiveMovement)
                {
                    SelectMovement(aggressiveMovement);
                }
            }
            else
            {
                if (currentMovement != randomMovement)
                {
                    SelectMovement(randomMovement);
                }
            }
        }
        
        private void SelectMovement(Movement newMovement)
        {
            currentMovement.enabled = false;
            currentMovement = newMovement;
            currentMovement.enabled = true;
        }
    } 
}


