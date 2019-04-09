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

    public void fireWeapon(int weaponType)
    {
        switch (weaponType)
        {
            case 0:
                {
                    if (Time.time > nextFire)
                    {
                        //make vector of ship direction
                        fireVector0 = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
                        //create a new cannonball on the bulletSpawn
                        nextFire = Time.time + stats.FireRate;
                        var bullet = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        bullet.GetComponent<ProjectileController>().direction = fireVector0;
                    }
                    break;
                }

            case 1:
                {
                    if (Time.time > nextFire)
                    {
                        //make vector of ship direction
                        fireVector0 = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
                        fireVector1 = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);
                        fireVector2 = new Vector2(BulletSpawn.position.x - transform.position.x, BulletSpawn.position.y - transform.position.y);

                        fireVector1 = RotateVector(fireVector1, 20);
                        fireVector2 = RotateVector(fireVector2, -20);
                        //create a new cannonball on the bulletSpawn
                        nextFire = Time.time + stats.FireRate;
                        var bullet0 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet1 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        var bullet2 = Instantiate(shot, BulletSpawn.position, BulletSpawn.rotation);
                        bullet0.GetComponent<ProjectileController>().direction = fireVector0;
                        bullet1.GetComponent<ProjectileController>().direction = fireVector1;
                        bullet2.GetComponent<ProjectileController>().direction = fireVector2;
                    }
                    break;
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
