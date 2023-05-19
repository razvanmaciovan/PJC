using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityTypes;
using static System.Collections.Specialized.BitVector32;

public class GearSelectionUI : MonoBehaviour
{
    public Image SelectWeaponImage;
    public Image SelectHelmetImage;
    public Image SelectBodyImage;
    public Image SelectBootsImage;

    [SerializeField]
    private GameObject _gearItemPrefab, _inventoryEquipmentPlaceholder, _inventoryWeaponsPlaceholder;
    // Start is called before the first frame update
    void Start()
    {
        ChangeSelectedWeapon(DataManager.Instance.PlayerData.EquippedWeapon);
        ChangeSelectedHelmet(DataManager.Instance.PlayerData.EquippedHelmet);
        ChangeSelectedBody(DataManager.Instance.PlayerData.EquippedBody);
        ChangeSelectedBoots(DataManager.Instance.PlayerData.EquippedBoots);
        DisplayAllOwnedItemsInInventory();
    }

    public void ChangeSelectedWeapon(WeaponScriptableObject weapon)
    {
        SelectWeaponImage.sprite = weapon.WeaponPrefab.GetComponent<SpriteRenderer>().sprite;
        DataManager.Instance.PlayerData.EquippedWeapon = weapon;
        UiManager.Instance.RefreshPlayerGear(false);
    }

    public void ChangeSelectedHelmet(EquipmentScriptableObject helmet)
    {
        SelectHelmetImage.sprite = helmet.IconSprite;
        DataManager.Instance.PlayerData.EquippedHelmet = helmet;
        UiManager.Instance.RefreshPlayerGear(false);
    }
    public void ChangeSelectedBody(EquipmentScriptableObject body)
    {
        SelectBodyImage.sprite = body.IconSprite;
        DataManager.Instance.PlayerData.EquippedBody = body;
        UiManager.Instance.RefreshPlayerGear(false);
    }
    public void ChangeSelectedBoots(EquipmentScriptableObject boots)
    {
        SelectBootsImage.sprite = boots.IconSprite;
        DataManager.Instance.PlayerData.EquippedBoots = boots;
        UiManager.Instance.RefreshPlayerGear(false);
    }

    public void DisplayAllOwnedItemsInInventory()
    {
        DataManager.Instance.PlayerData.UnlockedEquipment.ForEach(e =>
        {
            var obj = Instantiate(_gearItemPrefab, _inventoryEquipmentPlaceholder.transform);
            var objScript = obj.GetComponent<GearSelectionItem>();
            objScript.Equipment = e;
            objScript.SetIcon();

        });

        DataManager.Instance.PlayerData.UnlockedWeapons.ForEach(w =>
        {
            var obj = Instantiate(_gearItemPrefab, _inventoryWeaponsPlaceholder.transform);
            var objScript = obj.GetComponent<GearSelectionItem>();
            objScript.Weapon = w;
            objScript.SetIcon();
        });
    }

}
