namespace Enemy
{
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.AI;

    public class AggressiveMovement : Movement
    {
        [SerializeField] private float stopRange;
    
        void Update()
        {
            if (!CanSeePlayer()) return;
            
            FaceTarget();
            if (DistanceToTarget() > stopRange)
            {
                GoTo(target.position);
            }
        }
    }
}