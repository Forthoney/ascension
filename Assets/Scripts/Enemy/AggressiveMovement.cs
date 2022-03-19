namespace Enemy
{
    using UnityEngine;

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