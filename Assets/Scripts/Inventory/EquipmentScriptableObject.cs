using Equipment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "ScriptableObjects/Gear/Equipment")]
public class EquipmentScriptableObject : ScriptableObject
{
    public string Name;
    public int EquipmentLevel;
    public EquipmentType EquipmentType;
    public RuntimeAnimatorController AnimatorController;
    public Sprite IconSprite;
}
