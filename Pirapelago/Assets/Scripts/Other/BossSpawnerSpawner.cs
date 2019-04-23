using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerSpawner : MonoBehaviour
{
    public GameObject bossSpawner;
    public GameObject[] spawners;

    void Awake()
    {
        int islandIndex = Random.Range(0, spawners.Length);
        Instantiate(bossSpawner, spawners[islandIndex].transform.position, spawners[islandIndex].transform.rotation);

    }
}
