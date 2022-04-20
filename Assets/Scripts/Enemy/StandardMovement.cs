namespace Enemy
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class StandardMovement : Movement
    {
        [SerializeField] private float changeBehaviorProximity = 15f;
        private Movement currentMovement;
        void Update()
        {
            if (DistanceToTarget() > changeBehaviorProximity)
            {
                SelectMovement(gameObject.GetComponent<AggressiveMovement>());
            }
            else
            {
                SelectMovement(gameObject.GetComponent<RandomMovement>());
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


