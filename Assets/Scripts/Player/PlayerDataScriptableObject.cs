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

}
