using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombatWave
{
    [SerializeField] public EnemySpawn[] enemies;
    [SerializeField] public int minEnemies = 3;
    [SerializeField] public int maxEnemies = 6;
    [SerializeField] public int startEnemies = 3;
    [SerializeField] public float enemySpawnTime = 5.0f;
    [SerializeField] public float enemySpawnTimeOffset = 1.0f; 



    public EnemySpawn GetEnemy(int index) 
    {
        return enemies[index];
        
    }

}
