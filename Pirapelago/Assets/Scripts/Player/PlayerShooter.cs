using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    public Vector2 direction;
    public float destroyTime;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Adds force to the bullet Rigidbody component
        rb2d.AddForce(direction * speed);
    }

    void FixedUpdate()
    {
        //Destroy the cannonball after an amount of time
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        
    }
}
