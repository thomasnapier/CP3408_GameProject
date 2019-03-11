using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int acceleration;
    public int maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     //assigns the rigidbody to the rb2d variable
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Takes user imput and adds forces to the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * acceleration);
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
    
    }
}
