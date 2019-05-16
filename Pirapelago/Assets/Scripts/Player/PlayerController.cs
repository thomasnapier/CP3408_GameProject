using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public int acceleration;
    public GameObject director;
    public Slider lifeBar;
    public bool dead = false;
    Vector3 mousePositionInWorld;
    float angle;
    public float startRotationOffset;  //This is angle offset at starting.
    private CharacterStats stats;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();     //assigns the rigidbody to the rb2d variable
        stats = gameObject.GetComponent<CharacterStats>();
        GameObject.Find("GameManager").GetComponent<PlayerEquipment>().updatePlayerStats();
        GetComponent<CharacterStats>().WeaponType = GameObject.Find("GameManager").GetComponent<AnyManager>().selectedWeapon;
        lifeBar.maxValue = stats.MaxHealth;
        lifeBar.value = stats.CurrentHealth;
        AstarPath.active.Scan();
    }

    public void killSelf()
    {
        dead = true;
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
            gameObject.GetComponent<CharacterShoot>().fireWeapon(stats.WeaponType);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyProjectile")
        {
            stats.CurrentHealth -= collision.gameObject.GetComponent<ProjectileController>().damage;
            lifeBar.value = stats.CurrentHealth;
            Destroy(collision.gameObject);
            if (stats.CurrentHealth == 0 && !dead)
            {
                dead = true;
                //TODO die
                GameObject.Find("Canvas").transform.Find("EndGame").gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
