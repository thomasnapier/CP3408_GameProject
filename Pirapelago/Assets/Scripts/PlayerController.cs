﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int acceleration;
    public int maxSpeed;
    public GameObject director;


    Vector3 mousePositionInWorld;
    float angle;
    public float speedFector;
    public float startRotationOffset;  //This is angle offset at starting.

    public GameObject shot;
    public Transform BulletSpawn;
    public float fireRate;
    private float nextFire;
    public float destroyTime;
    public Vector2 fireVector;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     //assigns the rigidbody to the rb2d variable
    }

    void FixedUpdate()
    {
        //Takes user imput and adds forces to the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * acceleration);
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
    
    }

    void Update()
    {
        //Make ship rotate to face mouse position
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = (Mathf.Atan2(mousePositionInWorld.y - transform.position.y, mousePositionInWorld.x - transform.position.x) * Mathf.Rad2Deg);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle + startRotationOffset), speedFector * Time.deltaTime);

        //Instantiates a new bullet when the mouse is clicked or held down every (nextFire) often for (destroyTime) amount of time
        if (Input.GetButton("Fire1") && Time.time > nextFire)
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
