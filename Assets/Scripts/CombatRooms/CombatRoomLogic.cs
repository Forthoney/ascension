using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class CombatRoomLogic : Triggerable
{
    
    public CombatWave[] waves;
    public int curWave = 0;
    

    private int curEnemies = 0;
    private int curWaveEnemy = 0;

    public LevelTrigger onEndTrigger;

    private float curEnemySpawnTime = -1.0f;

    



    public override void onTriggered()
    {
        StartNewWave();
    }

    public void Update()
    {
        if (curEnemySpawnTime > 0.0f)
        {
            curEnemySpawnTime -= Time.deltaTime;

            // If there are less than the maximum amount and the cooldown is up, start spawning more on a timer
            if (curEnemies < waves[curWave].maxEnemies)
            {
                if (curEnemySpawnTime <= 0.0f)
                {
                    SpawnEnemy();
                }
            }
        }
    }


    public void CheckWave()
    {
        // Spawn an enemy if there are less than the minimum amount
        if (curEnemies < waves[curWave].minEnemies)
        {
            SpawnEnemy();
            
        }
    }

    public void StartNewWave()
    {
        curWaveEnemy = 0; 
        CombatWave wave = waves[curWave];
        for (int i = 0; i < wave.startEnemies; i++)
        {
            try
            {
               SpawnEnemy();
            }
            catch (System.IndexOutOfRangeException e)
            {
                print("out of bounds error in combat room! check wave number or start enemies.");
            }
        }
        
    }

    public void OnWaveEnd()
    {
        curWave++;

        if (curWave < waves.Length)
        {
            StartNewWave();
        }
        else
        {
            onEndTrigger.ActivateTrigger();
        }
    }


    public void SpawnEnemy()
    {
        CombatWave wave = waves[curWave];
        // Get the current enemy from the current wave
        EnemySpawn spawn = wave.enemies[curWaveEnemy];

        GameObject ob = Instantiate(spawn.toSpawn, spawn.spawnLocation);
        ob.transform.parent = null;

        MortalInfo info;
        ob.TryGetComponent<MortalInfo>(out info);

        if (info != null)
        {
            // TODO, hook up on death event with on enemy death
        }

        // Reset Timer
        curEnemySpawnTime = wave.enemySpawnTime + Random.Range(-wave.enemySpawnTimeOffset, wave.enemySpawnTimeOffset);

        curWaveEnemy++; 
        curEnemies++; 
    }


    public void OnEnemyDeath()
    {
        curEnemies--; 
    }
}
