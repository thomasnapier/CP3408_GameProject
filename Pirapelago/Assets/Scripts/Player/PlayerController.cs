using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int acceleration;
    public GameObject director;

    Vector3 mousePositionInWorld;
    float angle;
    public float startRotationOffset;  //This is angle offset at starting.

    private CharacterStats stats;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     //assigns the rigidbody to the rb2d variable
        stats = gameObject.GetComponent<CharacterStats>();
    }

    void FixedUpdate()
    {
        //Takes user imput and adds forces to the player
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * acceleration);
        rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, stats.Speed);
    
    }

    void Update()
    {
        //Make ship rotate to face mouse position
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = (Mathf.Atan2(mousePositionInWorld.y - transform.position.y, mousePositionInWorld.x - transform.position.x) * Mathf.Rad2Deg);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle + startRotationOffset), stats.RotationSpeed * Time.deltaTime);
        //Instantiates a new bullet when the mouse is clicked or held down every (nextFire) often for (destroyTime) amount of time
        if (Input.GetButton("Fire1"))
        {
            gameObject.GetComponent<CharacterShoot>().fireWeapon();
        }
    }
}
