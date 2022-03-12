using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{ 
    [SerializeField] private float viewRange = 40f;
    [SerializeField] private float stopRange = 5f; 
    [SerializeField] private float turnRate = 5f;
    [SerializeField] private float moveRate = 1f;
    [SerializeField] private GameObject player;

    private float stepMove;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        stepMove = moveRate * Time.deltaTime;
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer()) 
        {
            FaceTarget();
            MoveToTarget();
        }
    }

    private bool CanSeePlayer() 
    {
        float distance = Vector3.Distance(target.position, transform.position);
        return (distance <= viewRange);
    }

    private void FaceTarget() 
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnRate);
    }

    private void MoveToTarget() 
    {
        if (Vector3.Distance(target.position, transform.position) > stopRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, stepMove);
        }
    }
}
