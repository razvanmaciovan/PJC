using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTypes;

public class UiManager : Singleton<UiManager>
{
    public void RefreshPlayerGear(bool shouldWeaponBeUsable = true)
    {
        var player = GameObject.FindGameObjectWithTag(UnityTags.Player.ToString()).GetComponent<PlayerController>();
        var weaponSlot = player.WeaponSlot;
        if (weaponSlot.transform.childCount > 0)
        {
            foreach (Transform child in weaponSlot.transform)
            {
                Destroy(child.gameObject);
            }
        }

        DataManager.Instance.PlayerData.EquippedWeapon.Spawn(weaponSlot.transform, shouldWeaponBeUsable);
        player.HeadAnimator.runtimeAnimatorController =
            DataManager.Instance.PlayerData.EquippedHelmet.AnimatorController;
        player.BodyAnimator.runtimeAnimatorController = DataManager.Instance.PlayerData.EquippedBody.AnimatorController;
        player.BootsAnimator.runtimeAnimatorController =
            DataManager.Instance.PlayerData.EquippedBoots.AnimatorController;
    }
}
