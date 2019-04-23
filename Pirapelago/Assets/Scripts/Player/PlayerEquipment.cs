using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    private static int basicShotLevel;
    private static int tripleShotLevel;
    private static int grapeShotLevel;
    private static int chainShotLevel;
    private static int explosionShotLevel;
    private static int sailLevel = 1;
    private static int rudderLevel = 1;
    private static int hullLevel = 1;
    private CharacterStats playerStats;

    private void Start()
    {
        updatePlayerStats();
    }

    public static int BasicShotLevel
    {
        get { return BasicShotLevel; }

        set
        {
            if (value < 0)
                BasicShotLevel = 0;
            else
                BasicShotLevel = value;
        }
    }

    public static int TripleShotLevel
    {
        get { return TripleShotLevel; }

        set
        {
            if (value < 0)
                TripleShotLevel = 0;
            else
                TripleShotLevel = value;
        }
    }

    public static int GrapeShotLevel
    {
        get { return GrapeShotLevel; }

        set
        {
            if (value < 0)
                GrapeShotLevel = 0;
            else
                GrapeShotLevel = value;
        }
    }

    public static int ChainShotLevel
    {
        get { return ChainShotLevel; }

        set
        {
            if (value < 0)
                ChainShotLevel = 0;
            else
                ChainShotLevel = value;
        }
    }

    public static int ExplosionShotLevel
    {
        get { return ExplosionShotLevel; }

        set
        {
            if (value < 0)
                ExplosionShotLevel = 0;
            else
                ExplosionShotLevel = value;
        }
    }

    public static int SailLevel
    {
        get { return SailLevel; }

        set
        {
            if (value < 0)
                SailLevel = 0;
            else
                SailLevel = value;
        }
    }

    public static int RudderLevel
    {
        get { return RudderLevel; }

        set
        {
            if (value < 0)
                RudderLevel = 0;
            else
                RudderLevel = value;
        }
    }

    public static int HullLevel
    {
        get { return HullLevel; }

        set
        {
            if (value < 0)
                HullLevel = 0;
            else
                HullLevel = value;
        }
    }

    public void updatePlayerStats()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        int[] weaponLevels = {basicShotLevel, tripleShotLevel, grapeShotLevel, explosionShotLevel, chainShotLevel};
        playerStats.MaxHealth = hullLevel *  100;
        playerStats.CurrentHealth = playerStats.MaxHealth;
        playerStats.Speed = sailLevel;
        playerStats.RotationSpeed = rudderLevel;
        for (int i = 0; i < playerStats.WeaponFireRate.Length; i++)
        {
            playerStats.changeWeaponFireRateValue(i, (float)System.Math.Pow(0.95, weaponLevels[i]) + 1);
        }
    }
}
