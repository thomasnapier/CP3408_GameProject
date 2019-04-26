using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject[] equipmentObjects = new GameObject[5];
    public void changeWeapon(int weapon)
    {
        character = GameObject.FindGameObjectWithTag("Player");
        character.GetComponent<CharacterStats>().WeaponType = weapon;
        for (int i = 0; i < 5; i++)
        {
            equipmentObjects[i].transform.Find("Panel").gameObject.SetActive(false);
        }
        equipmentObjects[weapon].transform.Find("Panel").gameObject.SetActive(true);
    }
}
