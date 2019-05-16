using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public GameObject shot;
    public GameObject tripleShot;
    public GameObject grapeShot;
    public GameObject explosiveShot;
    public GameObject chainShot;
    private Transform BulletSpawn;
    private float nextFire;
    private Vector2[] fireVectors = new Vector2[21];
    private GameObject[] bullets = new GameObject[21];
    private CharacterStats stats;
    private ProjectileController projectileController;
    public GameObject explosionObject;
    public AudioClip shootSound1;
    public AudioClip shootSound2;



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
            SoundManager.instance.RandomizeSfx(shootSound1, shootSound2); //play cannonfire sound 
            Instantiate(explosionObject, BulletSpawn.position, BulletSpawn.rotation);
            switch (weaponType)
            {
                case 0: //normal fire
                    {

                        //make vector of ship direction
                        fireVectors[0] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y).normalized;
                        //create a new cannonball on the bulletSpawn
                        nextFire = Time.time + stats.WeaponFireRate[0];
                        bullets[0] = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        bullets[0].GetComponent<ProjectileController>().direction = fireVectors[0];
                        
                        break;
                    }

                case 1: //triple mode
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            fireVectors[i] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y).normalized;
                            bullets[i] = Instantiate(tripleShot, BulletSpawn.position, BulletSpawn.rotation);


                        }
                        fireVectors[1] = RotateVector(fireVectors[1], 20);
                        fireVectors[2] = RotateVector(fireVectors[2], -20);

                        for (int i = 0; i < 3; i++)
                        {
                            bullets[i].GetComponent<ProjectileController>().direction = fireVectors[i];
                        }
                        nextFire = Time.time + stats.WeaponFireRate[1];
                        
                        break;
                    }
                case 2: //grape shot
                    {                        fireVectors[0] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y).normalized;

                        for (int i = 1; i < 9; i++)
                        {
                            bullets[i] = Instantiate(grapeShot, BulletSpawn.position, BulletSpawn.rotation);
                            fireVectors[i] = RotateVector(fireVectors[0], Random.Range(-20, 20));
                            bullets[i].GetComponent<ProjectileController>().direction = fireVectors[i];
                        }

                        //make vector of ship direction
                        fireVectors[0] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y).normalized;
                        nextFire = Time.time + stats.WeaponFireRate[2];
                        break;
                    }
                case 3: //explosive shot
                    {
                        fireVectors[0] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y).normalized;
                        nextFire = Time.time + stats.WeaponFireRate[3];
                        var bullet = Instantiate(explosiveShot, BulletSpawn.position, BulletSpawn.rotation);
                        bullet.GetComponent<ProjectileController>().direction = fireVectors[0];
                        break;
                    }
                case 4: //chain shot
                    {
                        fireVectors[0] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y).normalized;
                        nextFire = Time.time + stats.WeaponFireRate[4];
                        var bullet = Instantiate(chainShot, BulletSpawn.position, BulletSpawn.rotation);
                        bullet.GetComponent<ProjectileController>().direction = fireVectors[0];
                        break;
                    }
                case 5: //boss shot 1
                    {
                        for (int i = 0; i < 18; i++)
                        {
                            fireVectors[i] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y).normalized;
                            bullets[i] = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                            fireVectors[i] = RotateVector(fireVectors[i], i * 20);
                        }
                        for (int i = 0; i < 18; i++)
                        {
                            bullets[i].GetComponent<ProjectileController>().direction = fireVectors[i];
                        }
                        nextFire = Time.time + 1;
                        break;
                    }
                case 6: //boss shot 2
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            fireVectors[i] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y).normalized;
                            bullets[i] = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                            fireVectors[i] = RotateVector(fireVectors[i], -i * 10 - 40);
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            fireVectors[i + 10] = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y).normalized;
                            bullets[i + 10] = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                            fireVectors[i + 10] = RotateVector(fireVectors[i + 10], i * 10 + 40);
                        }
                        for (int i = 0; i < 20; i++)
                        {
                            bullets[i].GetComponent<ProjectileController>().direction = fireVectors[i];
                        }
                        nextFire = Time.time + .2f;
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
