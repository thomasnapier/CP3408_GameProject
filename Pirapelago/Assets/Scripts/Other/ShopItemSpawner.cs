using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemSpawner : MonoBehaviour
{
    public GameObject prefab;
    public GameObject instantiation;


    private void Start()
    {
        instantiation = Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation);
        instantiation.transform.SetParent(gameObject.transform, false);
        instantiation.transform.position = gameObject.transform.position;
    }
}
