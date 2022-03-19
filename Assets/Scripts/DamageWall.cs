using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWall : SpecialWallBehavior
{

    [SerializeField] private int wallDamage;
    [SerializeField] private int speedMultiplier = 1;

    public override bool StartWallCollisionBehavior(GameObject player, Vector3 normal) {
        MortalInfo playerInfo = player.GetComponent<MortalInfo>();
        playerInfo.TakeDamage(wallDamage);
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        playerMovement.SetVelocity(speedMultiplier * Vector3.Reflect(playerMovement.GetVelocity(), normal));
        return true;
    }

}
