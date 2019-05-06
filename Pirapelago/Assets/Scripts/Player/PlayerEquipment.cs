using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipment : MonoBehaviour
{
    private static int basicShotLevel = 1;
    private static int tripleShotLevel = 0;
    private static int grapeShotLevel = 0;
    private static int chainShotLevel = 0;
    private static int explosionShotLevel = 0;
    private static int sailLevel = 1;
    private static int rudderLevel = 1;
    private static int hullLevel = 1;
    private CharacterStats playerStats;

    private void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            updatePlayerStats();
        }
    }

    public static int BasicShotLevel
    {
        get { return basicShotLevel; }

        set
        {
            if (value < 0)
                basicShotLevel = 0;
            else
                basicShotLevel = value;
        }
    }

    public static int TripleShotLevel
    {
        get { return tripleShotLevel; }

        set
        {
            if (value < 0)
                tripleShotLevel = 0;
            else
                tripleShotLevel = value;
        }
    }

    public static int GrapeShotLevel
    {
        get { return grapeShotLevel; }

        set
        {
            if (value < 0)
                grapeShotLevel = 0;
            else
                grapeShotLevel = value;
        }
    }

    public static int ChainShotLevel
    {
        get { return chainShotLevel; }

        set
        {
            if (value < 0)
                chainShotLevel = 0;
            else
                chainShotLevel = value;
        }
    }

    public static int ExplosionShotLevel
    {
        get { return explosionShotLevel; }

        set
        {
            if (value < 0)
                explosionShotLevel = 0;
            else
                explosionShotLevel = value;
        }
    }

    public static int SailLevel
    {
        get { return sailLevel; }

        set
        {
            if (value < 0)
                sailLevel = 0;
            else
                sailLevel = value;
        }
    }

    public static int RudderLevel
    {
        get { return rudderLevel; }

        set
        {
            if (value < 0)
                rudderLevel = 0;
            else
                rudderLevel = value;
        }
    }

    public static int HullLevel
    {
        get { return hullLevel; }

        set
        {
            if (value < 0)
                hullLevel = 0;
            else
                hullLevel = value;
        }
    }

    public void updatePlayerStats()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        int[] weaponLevels = {basicShotLevel, tripleShotLevel, grapeShotLevel, explosionShotLevel, chainShotLevel};
        playerStats.MaxHealth = hullLevel *  100;
        playerStats.CurrentHealth = playerStats.MaxHealth;
        playerStats.Speed = (float)(2 * System.Math.Log(sailLevel)) + 2;
        playerStats.RotationSpeed = rudderLevel;
        for (int i = 0; i < playerStats.WeaponFireRate.Length; i++)
        {
            playerStats.changeWeaponFireRateValue(i, (float)System.Math.Pow(0.95, weaponLevels[i]));
        }
        GameObject.Find("Canvas").transform.Find("healthSlider").GetComponent<Slider>().value = playerStats.CurrentHealth;
    }
}
