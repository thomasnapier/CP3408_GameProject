using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotExplode : MonoBehaviour
{
    [SerializeField]
    private GameObject shrapnel;
    private Vector2[] fireVectors = new Vector2[4];
    private GameObject[] bullets = new GameObject[4];
    [SerializeField]
    private GameObject explosionObject;


    //when main bullet gets destroyed, make 4 new bullets from its destroy position
    public void explode()
    {
        fireVectors[0] = new Vector2(1, 1);
        fireVectors[1] = new Vector2(1, -1);
        fireVectors[2] = new Vector2(-1, 1);
        fireVectors[3] = new Vector2(-1, -1);
        Instantiate(explosionObject, gameObject.transform.position, gameObject.transform.rotation);

        for (int i = 0; i < 4; i++)
        {
            bullets[i] = Instantiate(shrapnel, gameObject.transform.position, gameObject.transform.rotation);
            bullets[i].GetComponent<ProjectileController>().direction = fireVectors[i];

        }
    }

}
