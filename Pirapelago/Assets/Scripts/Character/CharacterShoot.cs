using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour
{
    public GameObject shot;
    private Transform BulletSpawn;
    private float nextFire;
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
                        fireVector0 = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
                        //create a new cannonball on the bulletSpawn
                        nextFire = Time.time + stats.FireRate;
                        var bullet = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        bullet.GetComponent<ProjectileController>().direction = fireVector0;
                        
                        break;
                    }

                case 1: //god mode
                    {

                        //make vector of ship direction
                        fireVector0 = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
                        fireVector1 = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
                        fireVector2 = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);

                        fireVector1 = RotateVector(fireVector1, 20);
                        fireVector2 = RotateVector(fireVector2, -20);
                        //create a new cannonball on the bulletSpawn
                        shot.transform.localScale = new Vector3(0.15f, 0.15f, 0);
                        nextFire = Time.time + stats.FireRate;
                        var bullet0 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet1 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet2 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        bullet0.GetComponent<ProjectileController>().direction = fireVector0;
                        bullet1.GetComponent<ProjectileController>().direction = fireVector1;
                        bullet2.GetComponent<ProjectileController>().direction = fireVector2;
                        
                        break;
                    }
                case 2: //grape shot
                    {
                        //make vector of ship direction
                        fireVector0 = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
                        //create a new cannonball on the bulletSpawn
                        stats.FireRate = 2;


                        //change damage value
                        //change destroytime
                        //change velocity

                        nextFire = Time.time + stats.FireRate;

                        shot.transform.localScale = new Vector3(0.1f, 0.1f, 0);
                        
                        var bullet0 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet1 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet2 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet3 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet4 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet5 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet6 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet7 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet8 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                      
                        fireVector1 = RotateVector(fireVector0, Random.Range(-20, 20));
                        fireVector2 = RotateVector(fireVector0, Random.Range(-20, 20));
                        fireVector3 = RotateVector(fireVector0, Random.Range(-20, 20));
                        fireVector4 = RotateVector(fireVector0, Random.Range(-20, 20));
                        fireVector5 = RotateVector(fireVector0, Random.Range(-20, 20));
                        fireVector6 = RotateVector(fireVector0, Random.Range(-20, 20));
                        fireVector7 = RotateVector(fireVector0, Random.Range(-20, 20));
                        fireVector8 = RotateVector(fireVector0, Random.Range(-20, 20));
                       
                        bullet0.GetComponent<ProjectileController>().direction = fireVector1;                   
                        bullet1.GetComponent<ProjectileController>().direction = fireVector2;                   
                        bullet2.GetComponent<ProjectileController>().direction = fireVector3;                   
                        bullet3.GetComponent<ProjectileController>().direction = fireVector4;                   
                        bullet4.GetComponent<ProjectileController>().direction = fireVector5;                   
                        bullet5.GetComponent<ProjectileController>().direction = fireVector6;                   
                        bullet6.GetComponent<ProjectileController>().direction = fireVector7;                   
                        bullet7.GetComponent<ProjectileController>().direction = fireVector8;                   
                        bullet8.GetComponent<ProjectileController>().direction = fireVector0;                   
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
