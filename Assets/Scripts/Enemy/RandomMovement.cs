using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class RandomMovement : Movement
    {
        [SerializeField] private float radius;
        private Vector3 anchor;

        void Awake()
        {
            anchor = transform.position;
        }
        
        void Update()
        {
            if (!CanSeePlayer()) return;
            
            FaceTarget();
            GoTo(anchor + Random.insideUnitSphere);
        }
    }
}
