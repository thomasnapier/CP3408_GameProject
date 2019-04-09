using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject shot;
    public Transform BulletSpawn;
    public float fireRate;
    private float nextFire;
    public Vector2 fireVector;
    // Start is called before the first frame update
    void Start()
    {
        BulletSpawn = gameObject.transform.Find("bulletSpawner");
        fireRate = 1f;
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
            nextFire = Time.time + fireRate;
            var bullet = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
            bullet.GetComponent<PlayerShooter>().direction = fireVector;
        }
    }
}
