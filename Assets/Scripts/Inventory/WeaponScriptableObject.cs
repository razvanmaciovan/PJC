using System.Collections;
using System.Collections.Generic;
using Equipment;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Gear/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    public string Name;
    public int EquipmentLevel;
    public int Damage;
    public int Delay;
    public WeaponType WeaponType;
    public RuntimeAnimatorController AnimatorController;
    public GameObject WeaponPrefab;

    public void Spawn(Transform handTransform, bool attack = true)
    {
        var spawned = Instantiate(WeaponPrefab, handTransform);
        spawned.GetComponent<WeaponController>().Init(this, attack);
    }
}
