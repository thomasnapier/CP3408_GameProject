using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            spawnBoss();
        }
    }

    public void spawnBoss()
    {
        Instantiate(boss, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
