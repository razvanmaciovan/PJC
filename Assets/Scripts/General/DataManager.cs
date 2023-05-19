using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public PlayerDataScriptableObject PlayerData;
    public GearDatabase AllGear;

    private const string PLAYER_DATA_PATH = "/PlayerData.json";

    public int GetPlayerEquipmentLevel() => (PlayerData.EquippedBody.EquipmentLevel +
                                            PlayerData.EquippedBoots.EquipmentLevel +
                                            PlayerData.EquippedHelmet.EquipmentLevel +
                                            PlayerData.EquippedWeapon.EquipmentLevel) / 4;

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

    public void SaveIntoJson()
    {
        print($"Saved to {Application.persistentDataPath + PLAYER_DATA_PATH}");
        var player = JsonUtility.ToJson(PlayerData, true);
        File.WriteAllText(Application.persistentDataPath + PLAYER_DATA_PATH, player);
    }

    public bool LoadJson()
    {
        if (!File.Exists(Application.persistentDataPath + PLAYER_DATA_PATH)) return false;
        string playerJson = File.ReadAllText(Application.persistentDataPath + PLAYER_DATA_PATH);

        JsonUtility.FromJsonOverwrite(playerJson, PlayerData);
        return true;
    }

}
