using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawner : MonoBehaviour
{
    public GameObject island1;
    public GameObject island2;
    public GameObject island3;
    public GameObject skullIsland;

    public int islandCount = 4;

    public int island1SpawnRate, island2SpawnRate, island3SpawnRate, islandSkullSpawnRate;


    void Awake()
    {
        int randomNum = Random.Range(0, 100);
        if (randomNum > 0 && randomNum < island1SpawnRate)
        {
            Instantiate(island1, GetComponent<Transform>().position, Quaternion.identity);
        }
        else if (randomNum > island1SpawnRate && randomNum < island2SpawnRate)
        {
            Instantiate(island2, GetComponent<Transform>().position, Quaternion.identity);
        }
        else if (randomNum > island2SpawnRate && randomNum < island3SpawnRate)
        {
            Instantiate(island3, GetComponent<Transform>().position, Quaternion.identity);
        }
        else if (randomNum > island3SpawnRate && randomNum < islandSkullSpawnRate)
        {
            Instantiate(skullIsland, GetComponent<Transform>().position, Quaternion.identity);
        }


    }

    private void Start()
    {
        AstarPath.active.Scan();
    }
}
