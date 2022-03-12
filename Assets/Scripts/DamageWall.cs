using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWall : WallBehavior
{

    [SerializeField] private int wallDamage;

    public override void StartWallCollisionBehavior(GameObject player) {
        MortalInfo playerInfo = player.GetComponent<MortalInfo>();
        playerInfo.TakeDamage(wallDamage);
    }

}
