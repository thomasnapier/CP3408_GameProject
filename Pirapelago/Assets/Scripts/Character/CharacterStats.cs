﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    private float currentHealth;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private int money;
    [SerializeField]
    private int weaponType;
    [SerializeField]
    private float[] weaponFireRate = new float[5]; 

    public float CurrentHealth
    {
        get { return currentHealth; }

        set
        {
            if (value < 0)
                currentHealth = 0;
            else
                currentHealth = value;
        }
    }

    public float MaxHealth
    {
        get { return maxHealth; }

        set
        {
            if (value < 0)
                maxHealth = 0;
            else
                maxHealth = value;
        }
    }

    public float Speed
    {
        get { return speed; }

        set
        {
            if (value < 0)
                speed = 0;
            else
                speed = value;
        }
    }

    public float RotationSpeed
    {
        get { return rotationSpeed; }

        set
        {
            if (value < 0)
                rotationSpeed = 0;
            else
                rotationSpeed = value;
        }
    }

    public int Money
    {
        get { return money; }

        set
        {
            if (value < 0)
                money = 0;
            else
                money = value;
        }
    }

    public int WeaponType
    {
        get { return weaponType; }

        set
        {
            if (value < 0)
                weaponType = 0;
            else
                weaponType = value;
        }
    }

    public float[] WeaponFireRate
    {
        get { return weaponFireRate; }
    }

    public void changeWeaponFireRateValue(int element, float value)
    {
        weaponFireRate[element] = value; 
    }


}
