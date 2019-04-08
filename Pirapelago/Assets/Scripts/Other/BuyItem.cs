using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    public GameObject coinText;
    public GameObject canvas;
    public GameObject healthSlider;
    public GameObject coinCounter;
    public GameObject boughtOverlay;
    public GameObject prefab;
    public GameObject instantiation;
    public int itemValue;
    int playerCoins;

    void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("canvas");
        healthSlider = canvas.transform.Find("healthSlider").gameObject;
        coinCounter = healthSlider.transform.Find("coinCounter").gameObject;
        coinText = coinCounter.transform.Find("coinText").gameObject;
        playerCoins = int.Parse(coinText.GetComponent<Text>().text);
        boughtOverlay = gameObject.transform.Find("boughtOverlay").gameObject;
        boughtOverlay.SetActive(false);
    }

    public void GetItemValue(int value)
    {
        itemValue = value;
        SubtractItemValue();
    }

    private void SubtractItemValue()
    {
        if(itemValue < playerCoins)
        {
            playerCoins -= itemValue;
            coinText.GetComponent<Text>().text = playerCoins.ToString();
            boughtOverlay.SetActive(true);
        }
    }
}
