using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialWallBehavior : MonoBehaviour
{
    public abstract bool StartWallCollisionBehavior(GameObject player, Vector3 normal);

}