using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageWall : MonoBehaviour
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

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            MortalInfo playerInfo = other.gameObject.GetComponent<MortalInfo>();
            playerInfo.TakeDamage(wallDamage);
        } 
    }
}
