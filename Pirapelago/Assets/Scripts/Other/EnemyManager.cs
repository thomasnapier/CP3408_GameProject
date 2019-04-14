using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public float spawnTime;
    public Transform[] spawnPoints;
    public GameObject enemy;
    public bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
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
                Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
                spawned = false;
            }
        }
    }

}
