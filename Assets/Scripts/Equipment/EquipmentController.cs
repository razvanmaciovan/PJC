using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentController : MonoBehaviour
{
    public void Init(WeaponScriptableObject weapon)
    {
        var anim = gameObject.GetComponent<Animator>();
        anim.runtimeAnimatorController = weapon.AnimatorController;
    }
}
