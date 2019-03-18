using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //Adds force to the bullet Rigidbody component
        Vector2 moveUp = new Vector2(0, 5);
        rb2d.AddForce(moveUp * speed);
    }

    void Update()
    {
        
    }
}
