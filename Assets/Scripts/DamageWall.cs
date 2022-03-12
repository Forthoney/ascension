using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWall : WallBehavior
{

    [SerializeField] private int wallDamage;

    public override void StartWallCollisionBehavior(GameObject player, Vector3 normal) {
        MortalInfo playerInfo = player.GetComponent<MortalInfo>();
        playerInfo.TakeDamage(wallDamage);
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.SetVelocity(10f * -Vector3.Reflect(playerMovement.GetVelocity(), normal));
    }

}
