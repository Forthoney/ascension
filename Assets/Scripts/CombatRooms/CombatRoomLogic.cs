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
        if (curEnemySpawnTime > 0.0f && curWave < waves.Length)
        {
            curEnemySpawnTime -= Time.deltaTime;

            // If there are less than the maximum amount and the cooldown is up, start spawning more on a timer
            if (curEnemies < waves[curWave].maxEnemies)
            {
                if (curEnemySpawnTime <= 0.0f)
                {
                    SpawnEnemy();
                    Debug.Log("Enemy spawned from timer");
                }
            }
        }
    }


    public void CheckWave()
    {
        // Spawn an enemy if there are less than the minimum amount
        if (curWave < waves.Length && curEnemies < waves[curWave].minEnemies)
        {
            SpawnEnemy();
            Debug.Log("Enemy spawned from minimum");
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
               Debug.Log("Enemy spawned from start");
            }
            catch (System.IndexOutOfRangeException e)
            {
                Debug.Log("out of bounds error in combat room! check wave number or start enemies.");
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

    public void CheckWaveEnd()
    {
        try
        {

            if (curWave < waves.Length)
            {
                CombatWave wave = waves[curWave];

                if (curWaveEnemy >= wave.enemies.Length && curEnemies <= 0)
                {
                    OnWaveEnd();
                }
            }
        }
        catch
        {
            Debug.Log("Check wave end error");
        }
    }


    public void SpawnEnemy()
    {
        CombatWave wave = waves[curWave];

        if (curWaveEnemy < wave.enemies.Length)
        {
            // Get the current enemy from the current wave
            EnemySpawn spawn = wave.enemies[curWaveEnemy];

            GameObject ob = Instantiate(spawn.toSpawn, spawn.spawnLocation);
            ob.transform.parent = null;

            MortalInfo info;
            ob.GetComponent<MortalInfo>().deathEvent.AddListener(OnEnemyDeath);
            //ob.TryGetComponent<MortalInfo>(out info);

            /*if (info != null)
            {
                info.deathEvent.AddListener(OnEnemyDeath);
                // TODO, hook up on death event with on enemy death
            }*/

            // Reset Timer
            curEnemySpawnTime = wave.enemySpawnTime + Random.Range(-wave.enemySpawnTimeOffset, wave.enemySpawnTimeOffset);

            curWaveEnemy++;
            curEnemies++;
        }
    }


    public void OnEnemyDeath()
    {
        curEnemies--;

        
        CheckWaveEnd();
        CheckWave();
    }
}
