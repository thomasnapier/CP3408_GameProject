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
        bool locked = false;
        switch (weapon)
        {
            case 0:
                if (PlayerEquipment.BasicShotLevel == 0)
                {
                    locked = true;
                }
                break;
            case 1:
                if (PlayerEquipment.TripleShotLevel == 0)
                {
                    locked = true;
                }
                break;
            case 2:
                if (PlayerEquipment.GrapeShotLevel == 0)
                {
                    locked = true;
                }
                break;
            case 3:
                if (PlayerEquipment.ExplosionShotLevel == 0)
                {
                    locked = true;
                }
                break;
            case 4:
                if (PlayerEquipment.ChainShotLevel == 0)
                {
                    locked = true;
                }
                break;
        }

        if (!locked)
        {
            for (int i = 0; i < 5; i++)
            {
                equipmentObjects[i].transform.Find("Panel").gameObject.SetActive(false);
            }
            equipmentObjects[weapon].transform.Find("Panel").gameObject.SetActive(true);
            character.GetComponent<CharacterStats>().WeaponType = weapon;
        }
    }
}
