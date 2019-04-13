using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyItem : MonoBehaviour
{
    public GameObject coinText;
    public GameObject canvas;
    public GameObject healthSlider;
    public GameObject coinCounter;
    public GameObject boughtOverlay;
    private CharacterStats playerStats;
    public int itemValue;
    int playerCoins;

    void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        canvas = GameObject.FindGameObjectWithTag("canvas");
        healthSlider = canvas.transform.Find("healthSlider").gameObject;
        coinCounter = healthSlider.transform.Find("coinCounter").gameObject;
        coinText = coinCounter.transform.Find("coinText").gameObject;
        coinText.GetComponent<TextMeshProUGUI>().text = playerStats.Money.ToString();
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
        if(itemValue < playerStats.Money)
        {
            playerStats.Money -= itemValue;

            coinText.GetComponent<TextMeshProUGUI>().text = playerStats.Money.ToString();
            boughtOverlay.SetActive(true);
        }
    }

    public void ChangeWeaponType(int wepType)
    {
        playerStats.WeaponType = wepType;
    }
}
