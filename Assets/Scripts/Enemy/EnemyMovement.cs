using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{ 
    public float viewRange = 40f;
    public float stopRange = 5f; 
    public float turnRate = 5f;
    public float moveRate = 1f;
    public GameObject player;

    float stepMove;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        stepMove = moveRate * Time.deltaTime;
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSeePlayer()) {
            FaceTarget();

            if (Vector3.Distance(target.position, transform.position) > stopRange)
            {
                MoveToTarget();
            }
        }
    }

    bool CanSeePlayer() {
        float distance = Vector3.Distance(target.position, transform.position);
        return (distance <= viewRange);
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnRate);
    }

    void MoveToTarget() {
        transform.position = Vector3.MoveTowards(transform.position, target.position, stepMove);
    }
}
