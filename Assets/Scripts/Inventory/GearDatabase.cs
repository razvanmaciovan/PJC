using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GearDatabase", menuName = "ScriptableObjects/Gear/Database")]
public class GearDatabase : ScriptableObject
{
    public List<EquipmentScriptableObject> Equipments;
    public List<WeaponScriptableObject> Weapons;
}
