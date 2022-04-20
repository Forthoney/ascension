using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class RandomMovement : Movement
    {
        [SerializeField] private float radius = 5;
        private Vector3 anchor;
        private Vector3 direction;
        private const int WallLayer = 1 << 9;

        void OnEnable()
        {
            anchor = transform.position;
            StartCoroutine(SelectDirection());
        }
        
        void Update()
        {
            if (!CanSeePlayer()) return;
            
            FaceTarget();
            GoTo(anchor + direction * radius);
        }

        IEnumerator SelectDirection()
        {
            for (;;)
            {
                direction = Random.insideUnitSphere;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out var hit, 0.3f, WallLayer))
                {
                    direction = -direction;
                }
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}
