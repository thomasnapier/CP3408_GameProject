using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIndicator : MonoBehaviour
{
    public Transform target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("BossSpawner").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            var dir = target.position - transform.position;

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
