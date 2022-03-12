using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWall : WallBehavior
{

    [SerializeField] private int wallDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void StartWallCollisionBehavior(GameObject player) {
        MortalInfo playerInfo = player.GetComponent<MortalInfo>();
        playerInfo.TakeDamage(wallDamage);
    }

}
