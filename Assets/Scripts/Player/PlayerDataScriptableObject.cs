using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData")]
public class PlayerDataScriptableObject : ScriptableObject
{
    public List<WeaponScriptableObject> UnlockedWeapons;
    public List<EquipmentScriptableObject> UnlockedEquipment;
    public WeaponScriptableObject EquippedWeapon;
    public EquipmentScriptableObject EquippedHelmet;
    public EquipmentScriptableObject EquippedBody;
    public EquipmentScriptableObject EquippedBoots;
    public EnemyListScriptableObject AvailableBosses;
    public EnemyListScriptableObject DefeatedBosses;

    private const string DEFAULT_PATH_EQUIPMENT = "ScriptableObjects/Equipment";
    private const string DEFAULT_PATH_WEAPON = "ScriptableObjects/Weapons";

    public void Reset()
    {
        var defaultWeapon = Resources.Load<WeaponScriptableObject>($"{DEFAULT_PATH_WEAPON}/WoodenSword");
        var defaultHelmet = Resources.Load<EquipmentScriptableObject>($"{DEFAULT_PATH_EQUIPMENT}/DefaultHead");
        var defaultBody = Resources.Load<EquipmentScriptableObject>($"{DEFAULT_PATH_EQUIPMENT}/DefaultBody");
        var defaultBoots = Resources.Load<EquipmentScriptableObject>($"{DEFAULT_PATH_EQUIPMENT}/DefaultBoots");

        DefeatedBosses.EnemyList.Clear();
        AvailableBosses.EnemyList.RemoveRange(3, AvailableBosses.EnemyList.Count - 3);
        UnlockedWeapons.RemoveRange(1, UnlockedWeapons.Count - 1);
        UnlockedEquipment.RemoveRange(3, UnlockedEquipment.Count - 3);
        EquippedWeapon = defaultWeapon;
        EquippedHelmet = defaultHelmet;
        EquippedBody = defaultBody;
        EquippedBoots = defaultBoots;

    }

}
