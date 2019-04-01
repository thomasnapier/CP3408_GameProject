using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterShop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject canvas;

    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("canvas");
        shopUI = canvas.transform.Find("shopUI").gameObject;
        //shopUI = GameObject.FindWithTag("MainCamera");
        //shopUI = GameObject.Find("Camvas/shopUI");

        Debug.Log(shopUI);
        shopUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shopUI.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            shopUI.SetActive(false);

        }
    }
}
