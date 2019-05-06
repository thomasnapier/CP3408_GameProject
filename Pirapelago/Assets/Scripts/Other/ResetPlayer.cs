using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public void resetGameManager()
    {
        AnyManager manager = GameObject.Find("GameManager").GetComponent<AnyManager>();
        manager.time = 0;
        manager.score = 0;
        manager.selectedWeapon = 0;
        PlayerEquipment.BasicShotLevel = 1;
        PlayerEquipment.TripleShotLevel = 0;
        PlayerEquipment.GrapeShotLevel = 0;
        PlayerEquipment.ChainShotLevel = 0;
        PlayerEquipment.ExplosionShotLevel = 0;
        PlayerEquipment.SailLevel = 1;
        PlayerEquipment.RudderLevel = 1;
        PlayerEquipment.HullLevel = 1;
    }
}
