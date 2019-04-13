using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemSpawner : MonoBehaviour
{
    List<GameObject> prefabs = new List<GameObject>();
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject prefab5;
    public GameObject prefab6;
    public GameObject prefab7;
    public GameObject instantiation;


    private void Start()
    {
        prefabs.Add(prefab1);
        prefabs.Add(prefab2);
        prefabs.Add(prefab3);
        prefabs.Add(prefab4);
        prefabs.Add(prefab5);
        prefabs.Add(prefab6);
        prefabs.Add(prefab7);
        int prefabIndex = UnityEngine.Random.Range(0, 7);
        instantiation = Instantiate(prefabs[prefabIndex], gameObject.transform.position, gameObject.transform.rotation);
        instantiation.transform.SetParent(gameObject.transform, false);
        instantiation.transform.position = gameObject.transform.position;        
    }
}
