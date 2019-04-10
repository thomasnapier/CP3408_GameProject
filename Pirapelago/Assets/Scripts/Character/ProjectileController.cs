using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float speed;
    public Vector2 direction;
    [SerializeField]
    private float destroyTime;
    public float damage;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Adds force to the bullet Rigidbody component
        rb2d.AddForce(direction * speed);
        Physics.IgnoreLayerCollision(9, 9);
    }

    void FixedUpdate()
    {
        //Destroy the cannonball after an amount of time
        Destroy(gameObject, destroyTime);
    }
}
