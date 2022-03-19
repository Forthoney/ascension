namespace Enemy
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using UnityEngine;
    using UnityEngine.AI;
    
    public abstract class Movement : MonoBehaviour
    { 
        [SerializeField] private float viewRange; 
        [SerializeField] private float turnRate;
        [SerializeField] private float moveRate;
        
        protected Transform target;

        void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    
        protected bool CanSeePlayer()
        {
            Vector3 currentPosition = transform.position;
            return Physics.Raycast(currentPosition, (target.position - currentPosition).normalized, out RaycastHit hit, viewRange);
        }
        
        protected void FaceTarget() 
        {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnRate);
        }

        protected float DistanceToTarget()
        {
            return Vector3.Distance(target.position, transform.position);
        }

        protected void GoTo(Vector3 location)
        {
            transform.position = Vector3.MoveTowards(transform.position, location, moveRate * Time.deltaTime);
        }
    }
}