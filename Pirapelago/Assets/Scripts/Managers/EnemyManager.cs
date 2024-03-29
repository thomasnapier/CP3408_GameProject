﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public float spawnTime;
    public Transform[] spawnPoints;
    public GameObject[] enemies;
    public bool spawned;
    int randomEnemyType;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        randomEnemyType = Random.Range(0, enemies.Length); //pick a random enemy
        if (player.GetComponent<CharacterStats>().CurrentHealth <= 0f)
        {
            return;
        }
        spawned = true;
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        while (spawned)
        {
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            if (spawnPoints[spawnPointIndex].gameObject.GetComponent<OverlapDetect>().collisions == 0)
            {
                var newEnemy = Instantiate(enemies[randomEnemyType], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                var stats = newEnemy.GetComponent<CharacterStats>();
                var fireRate = (float)System.Math.Pow(0.95, TimeManager.min) + 1;
                for (int i = 0; i < stats.WeaponFireRate.Length; i++)
                {
                    stats.changeWeaponFireRateValue(i, fireRate);
                }
                stats.Speed = 300 + (10 * TimeManager.min);
                stats.MaxHealth = 20 + (10 * TimeManager.min);
                stats.CurrentHealth = stats.MaxHealth;
                stats.Money += TimeManager.min;
                spawned = false;
            }
        }
        spawnTime -= .25f; //reduce spawntime by a quarter of a second each time
    }

}
