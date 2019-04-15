using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public GameObject shot;
    public GameObject tripleShot;
    public GameObject grapeShot;
    public GameObject explosiveShot;
    private Transform BulletSpawn;
    private float nextFire;
    private Vector2[] fireVectors = new Vector2[9];
    private GameObject[] bullets = new GameObject[9];
    private Vector2 fireVector0;
    private Vector2 fireVector1;
    private Vector2 fireVector2;
    private Vector2 fireVector3;
    private Vector2 fireVector4;
    private Vector2 fireVector5;
    private Vector2 fireVector6;
    private Vector2 fireVector7;
    private Vector2 fireVector8;
    private CharacterStats stats;
    private ProjectileController projectileController;
    public GameObject explosionObject;



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

    public void fireWeapon(int weaponType)
    {
        if (Time.time > nextFire)
        {
            Instantiate(explosionObject, BulletSpawn.position, BulletSpawn.rotation);
            switch (weaponType)
            {
                case 0: //normal fire
                    {

                        //make vector of ship direction
                        fireVectors[0] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
                        //create a new cannonball on the bulletSpawn
                        nextFire = Time.time + stats.FireRate;
                        bullets[0] = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        bullets[0].GetComponent<ProjectileController>().direction = fireVectors[0];
                        
                        break;
                    }

                case 1: //triple mode
                    {
                        //make vector of ship direction
                        for (int i = 0; i < 3; i++)
                        {
                            fireVectors[i] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
                            bullets[i] = Instantiate(tripleShot, BulletSpawn.position, BulletSpawn.rotation);


                        }
                        fireVectors[1] = RotateVector(fireVectors[1], 20);
                        fireVectors[2] = RotateVector(fireVectors[2], -20);

                        //create a new cannonball on the bulletSpawn
                        for (int i = 0; i < 3; i++)
                        {
                            bullets[i].GetComponent<ProjectileController>().direction = fireVectors[i];
                        }
                        nextFire = Time.time + stats.FireRate;
                        
                        break;
                    }
                case 2: //grape shot
                    {
                        //make vector of ship direction
                        //create a new cannonball on the bulletSpawn
                        fireVectors[0] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);

                        for (int i = 1; i < 9; i++)
                        {
                            bullets[i] = Instantiate(grapeShot, BulletSpawn.position, BulletSpawn.rotation);
                            fireVectors[i] = RotateVector(fireVectors[0], Random.Range(-20, 20));
                            bullets[i].GetComponent<ProjectileController>().direction = fireVectors[i];
                        }

                        //make vector of ship direction
                        fireVector0 = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
                        //create a new cannonball on the bulletSpawn
                        nextFire = Time.time + stats.FireRate;
                        break;
                    }
                case 3: //explosive shot
                    {
                        //make vector of ship direction
                        fireVector0 = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
                        //create a new cannonball on the bulletSpawn
                        nextFire = Time.time + stats.FireRate;
                        stats.FireRate = 3;
                        var bullet = Instantiate(explosiveShot, BulletSpawn.position, BulletSpawn.rotation);
                        bullet.GetComponent<ProjectileController>().direction = fireVector0;
                        break;
                    }
                    
            }

        }
    }


    public Vector2 RotateVector(Vector2 v, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float _x = v.x * Mathf.Cos(radian) - v.y * Mathf.Sin(radian);
        float _y = v.x * Mathf.Sin(radian) + v.y * Mathf.Cos(radian);
        return new Vector2(_x, _y);
    }
}
