using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class RewardManager : Singleton<RewardManager>
{
    public string LastReward;
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
                LastReward = eq.Name;
            }
            else
            {
                DataManager.Instance.PlayerData.UnlockedWeapons.Add(weapon);
                LastReward = weapon.Name;
            }
        } else if (eq == null && weapon == null)
        {
            //TODO Popup "Got all equipmenet for current level"
            print($"No gear for level {equipmentLevel}");
            LastReward = String.Empty;
        }
        else
        {
            if (eq != null)
            {
                DataManager.Instance.PlayerData.UnlockedEquipment.Add(eq);
                LastReward = eq.Name;
            }
            else
            {
                DataManager.Instance.PlayerData.UnlockedWeapons.Add(weapon);
                LastReward = weapon.Name;
            }
        }
    }
}
