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
    public float time;
    public GameObject splashObject;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //Adds force to the bullet Rigidbody component
        rb2d.AddForce(direction * speed);
        //Destroy(gameObject, destroyTime);
    }

    void FixedUpdate()
    {
        //Destroy the cannonball after an amount of time
        //Destroy(gameObject, destroyTime);
        time += Time.deltaTime;
        if (time >= destroyTime)
        {
            Instantiate(splashObject, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject, 0);
        }
    }
}
