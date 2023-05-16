using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : Singleton<RewardManager>
{
    public void OnBossKilled(int equipmentLevel)
    {
        var eq = DataManager.Instance.GetRandomEquipmentByLevel(equipmentLevel);
        var weapon = DataManager.Instance.GetRandomWeaponByLevel(equipmentLevel);
        if (eq != null && weapon != null)
        {
            var rand = Random.Range(0, 2);
            if (rand == 0)
            {
                DataManager.Instance.PlayerData.UnlockedEquipment.Add(eq);
            }
            else
            {
                DataManager.Instance.PlayerData.UnlockedWeapons.Add(weapon);
            }
        } else if (eq == null && weapon == null)
        {
            //TODO Popup "Got all equipmenet for current level"
        }
        else
        {
            if (eq != null)
            {
                DataManager.Instance.PlayerData.UnlockedEquipment.Add(eq);
            }
            else
            {
                DataManager.Instance.PlayerData.UnlockedWeapons.Add(weapon);
            }
        }
    }
}
