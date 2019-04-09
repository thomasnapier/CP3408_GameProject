using System.Collections;
using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyFollow : MonoBehaviour
{
    //what to chase
    public Transform target;
    //how many times each second we will update our path
    public float updateRate = 2f;
    //Caching
    private Seeker seeker;
    private Rigidbody2D rb2d;
    //the calculated path
    public Path path;

    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;
    //max distance from the ai to a waypoint for it to continue to the next waypoint
    public float nextWaypointDistance;
    //the waypoint we are currently moving towards
    private int currentWaypoint = 0;
    //distance the enemy will stay from the target
    public float stopApproachDistance;
    //didtance from the target that will cause the enemy to reverse
    public float reverseApproachDistance;
    //angel of enemy to target
    private float angle;
    //offset rotation of sprite
    public int startRotationOffset;

    private CharacterStats stats;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();
        stats = gameObject.GetComponent<CharacterStats>();
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            Debug.Log(target);
            yield return false;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void FixedUpdate()
    {
        if (target == null)
        {
            return;
        }

        angle = (Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle + startRotationOffset), stats.RotationSpeed * Time.deltaTime);


        if (path == null)
        {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            Debug.Log("End of path reached");
            pathIsEnded = true;
            return;
        }
        pathIsEnded = false;

        //direction to next waypoint
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= stats.Speed * Time.fixedDeltaTime;

        //Move the AI
        rb2d.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        //make the ship stop a distance from the player
        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (dist < nextWaypointDistance && distToTarget > stopApproachDistance)
        {
            if (distToTarget > stopApproachDistance)
            {
                currentWaypoint++;
                return;
            }
            else if (distToTarget < reverseApproachDistance)
            {
                //TODO: make enemy back off from the target
                return;
            }
        }
        else
        {
            gameObject.GetComponent<CharacterShoot>().fireWeapon();
        }
    }
}