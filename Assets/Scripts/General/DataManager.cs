using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public PlayerDataScriptableObject PlayerData;
    public GearDatabase AllGear;

    public int GetPlayerEquipmentLevel() => PlayerData.EquippedBody.EquipmentLevel +
                                            PlayerData.EquippedBoots.EquipmentLevel +
                                            PlayerData.EquippedHelmet.EquipmentLevel +
                                            PlayerData.EquippedWeapon.EquipmentLevel;

    public WeaponScriptableObject GetRandomWeaponByLevel(int level)
    {
        var validEquipments = AllGear.Weapons.Where(e => e.EquipmentLevel == level && !PlayerData.UnlockedWeapons.Contains(e)).ToList();
        return validEquipments.Count > 0 ? validEquipments[Random.Range(0, validEquipments.Count)] : null;
    }
    public EquipmentScriptableObject GetRandomEquipmentByLevel(int level)
    {
        var validEquipments = AllGear.Equipments.Where(e => e.EquipmentLevel == level && !PlayerData.UnlockedEquipment.Contains(e)).ToList();
        return validEquipments.Count > 0 ? validEquipments[Random.Range(0, validEquipments.Count)] : null;
    }

}
