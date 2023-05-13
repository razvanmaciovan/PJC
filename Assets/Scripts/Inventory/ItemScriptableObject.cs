using System.Collections;
using System.Collections.Generic;
using Equipment;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "ScriptableObjects/Inventory/Item")]
public class ItemScriptableObject : ScriptableObject
{
    public int Id;
    public string ItemName;
    [TextArea(15,20)]
    public string Description;
    public int EquipmentScore;
    public EquipmentType EquipmentType;
    public AnimatorOverrideController Animator;
    public Sprite Icon;
}