using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterShop : MonoBehaviour
{
    private GameObject shopUI;

    private void Start()
    {
        shopUI = GameObject.FindGameObjectWithTag("shopUI");
        shopUI.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        shopUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        shopUI.SetActive(false);
    }
}
