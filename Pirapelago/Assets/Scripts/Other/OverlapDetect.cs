using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapDetect : MonoBehaviour
{
    public int collisions = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisions++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisions--;
    }
}
