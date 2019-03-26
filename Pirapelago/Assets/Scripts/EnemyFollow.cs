using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float firingRange;
    private Transform target;
    float angle;
    public float speedFector;
    public float startRotationOffset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > firingRange){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        }
        else if (Vector2.Distance(transform.position, target.position) < firingRange - 1){
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
      
        }

        angle = (Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle + startRotationOffset), speedFector * Time.deltaTime);

    }
}
