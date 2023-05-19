using System.Collections;
using System.Collections.Generic;
using Equipment;
using UnityEngine;
using UnityEngine.UI;

public class GearSelectionItem : MonoBehaviour
{
    public EquipmentScriptableObject Equipment;
    public WeaponScriptableObject Weapon;
    public Image Icon;

    private GearSelectionUI _getGearSelectionUi;

    public void Start()
    {
        _getGearSelectionUi = GetComponentInParent<GearSelectionUI>();
    }

    public void SetIcon()
    {
        Icon.sprite = Weapon == null ? Equipment.IconSprite : Weapon.WeaponPrefab.GetComponent<SpriteRenderer>().sprite;
    }
    public void OnItemSelected()
    {
        if (Equipment == null)
        {
            _getGearSelectionUi.ChangeSelectedWeapon(Weapon);
        }
        else
        {
            if (Equipment.EquipmentType == EquipmentType.Head)
            {
                _getGearSelectionUi.ChangeSelectedHelmet(Equipment);
            }
            else if (Equipment.EquipmentType == EquipmentType.Body)
            {
                _getGearSelectionUi.ChangeSelectedBody(Equipment);
            }
            else
            {
                _getGearSelectionUi.ChangeSelectedBoots(Equipment);
            }
        }
    }
}
