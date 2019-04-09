using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public GameObject shot;
    private Transform BulletSpawn;
    private float nextFire;
    private Vector2 fireVector;
    private CharacterStats stats;

    // Start is called before the first frame update
    void Start()
    {
        BulletSpawn = gameObject.transform.Find("bulletSpawner");
        stats = gameObject.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void fireWeapon()
    {
        if (Time.time > nextFire)
        {
            //make vector of ship direction
            fireVector = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
            //create a new cannonball on the bulletSpawn
            nextFire = Time.time + stats.FireRate;
            var bullet = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
            bullet.GetComponent<ProjectileController>().direction = fireVector;
        }
    }
}
