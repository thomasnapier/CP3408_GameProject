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
    GameObject shopUI;
    GameObject equipment;
    GameObject hullUpgrade;
    GameObject hullUpgradeText;
    GameObject sailsUpgrade;
    GameObject sailsUpgradeText;
    GameObject ruddersUpgrade;
    GameObject ruddersUpgradeText;
    GameObject basicShotUpgrade;
    GameObject basicShotUpgradeText;
    GameObject tripleShotUpgrade;
    GameObject tripleShotUpgradeText;
    GameObject grapeShotUpgrade;
    GameObject grapeShotUpgradeText;
    GameObject explosiveShotUpgrade;
    GameObject explosiveShotUpgradeText;
    GameObject chainShotUpgrade;
    GameObject chainShotUpgradeText;
    private CharacterStats playerStats;
    [SerializeField]
    private PlayerEquipment playerEquipment;
    public int itemValue;
    int playerCoins;
    bool isPurchasable = false;

    void Awake()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        playerEquipment = GameObject.Find("GameManager").GetComponent<PlayerEquipment>();

        canvas = GameObject.FindGameObjectWithTag("canvas");
        healthSlider = canvas.transform.Find("healthSlider").gameObject;
        coinCounter = healthSlider.transform.Find("coinCounter").gameObject;
        coinText = coinCounter.transform.Find("coinText").gameObject;
        coinText.GetComponent<TextMeshProUGUI>().text = playerStats.Money.ToString();
        boughtOverlay = gameObject.transform.Find("boughtOverlay").gameObject;
        boughtOverlay.SetActive(false);

        shopUI = canvas.transform.Find("shopUI").gameObject;
        equipment = shopUI.transform.Find("Equipment").gameObject;

        //get the various level text components from the shop UI
        hullUpgrade = equipment.transform.Find("Hull Upgrade").gameObject;
        hullUpgradeText = hullUpgrade.transform.Find("HullUpgradeLevel").gameObject;

        ruddersUpgrade = equipment.transform.Find("Rudders Upgrade").gameObject;
        ruddersUpgradeText = ruddersUpgrade.transform.Find("RuddersLevel").gameObject;

        sailsUpgrade = equipment.transform.Find("Sails Upgrade").gameObject;
        sailsUpgradeText = sailsUpgrade.transform.Find("SailsLevel").gameObject;

        basicShotUpgrade = equipment.transform.Find("BasicShot").gameObject;
        basicShotUpgradeText = basicShotUpgrade.transform.Find("BasicShotLevel").gameObject;

        tripleShotUpgrade = equipment.transform.Find("TripleShot").gameObject;
        tripleShotUpgradeText = tripleShotUpgrade.transform.Find("TripleShotLevel").gameObject;

        grapeShotUpgrade = equipment.transform.Find("GrapeShot").gameObject;
        grapeShotUpgradeText = grapeShotUpgrade.transform.Find("GrapeShotLevel").gameObject;

        explosiveShotUpgrade = equipment.transform.Find("ExplosiveShot").gameObject;
        explosiveShotUpgradeText = explosiveShotUpgrade.transform.Find("ExplosiveShotLevel").gameObject;

        chainShotUpgrade = equipment.transform.Find("ChainShot").gameObject;
        chainShotUpgradeText = chainShotUpgrade.transform.Find("ChainShotLevel").gameObject;
    }

    public void GetItemValue(int value)
    {
        itemValue = value;
        SubtractItemValue();
    }

    private void SubtractItemValue()
    {
        if(itemValue <= playerStats.Money)
        {
            playerStats.Money -= itemValue;
            isPurchasable = true;

            coinText.GetComponent<TextMeshProUGUI>().text = playerStats.Money.ToString();
            boughtOverlay.SetActive(true);
            playerEquipment.updatePlayerStats();
        }
    }

    public void ChangeWeaponType(int wepType)
    {
        if (isPurchasable)
        {
            playerStats.WeaponType = wepType;
            UpgradePlayerWeapons(wepType);
            isPurchasable = false;
        }
    }

    public void SwapWeaponType(int wepType)
    {
        playerStats.WeaponType = wepType;
    }

    public void UpgradePlayerEquipment(int upgradeType)
    {
        if (isPurchasable)
        {
            switch (upgradeType)
            {
                case 0:
                    PlayerEquipment.HullLevel+=1;
                    hullUpgradeText.GetComponent<TextMeshProUGUI>().text = "Lvl " + PlayerEquipment.HullLevel;
                    break;
                case 1:
                    PlayerEquipment.SailLevel+=1;
                    sailsUpgradeText.GetComponent<TextMeshProUGUI>().text = "Lvl " + PlayerEquipment.SailLevel;
                    break;
                case 2:
                    PlayerEquipment.RudderLevel+=1;
                    ruddersUpgradeText.GetComponent<TextMeshProUGUI>().text = "Lvl " + PlayerEquipment.RudderLevel;
                    break;
            }
        }
    }

    public void UpgradePlayerWeapons(int wepType)
    {
        switch (wepType)
        {
            case 0:
                PlayerEquipment.BasicShotLevel += 1;
                basicShotUpgradeText.GetComponent<TextMeshProUGUI>().text = "Lvl " + PlayerEquipment.BasicShotLevel;
                break;
            case 1:
                PlayerEquipment.TripleShotLevel += 1;
                tripleShotUpgradeText.GetComponent<TextMeshProUGUI>().text = "Lvl " + PlayerEquipment.TripleShotLevel;
                break;
            case 2:
                PlayerEquipment.GrapeShotLevel += 1;
                grapeShotUpgradeText.GetComponent<TextMeshProUGUI>().text = "Lvl " + PlayerEquipment.GrapeShotLevel;
                break;
            case 3:
                PlayerEquipment.ExplosionShotLevel += 1;
                explosiveShotUpgradeText.GetComponent<TextMeshProUGUI>().text = "Lvl " + PlayerEquipment.ExplosionShotLevel;
                break;
            case 4:
                PlayerEquipment.ChainShotLevel += 1;
                chainShotUpgradeText.GetComponent<TextMeshProUGUI>().text = "Lvl " + PlayerEquipment.ChainShotLevel;
                break;
        }
    }
}
