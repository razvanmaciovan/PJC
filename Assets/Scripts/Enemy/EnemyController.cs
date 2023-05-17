using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int CurrentHitPoints;
    public int EquipmentLevel;
    public EnemyDifficulty SelectedDifficulty;

    public void TakeDamage(int damage)
    {

        CurrentHitPoints -= damage;
        if (CurrentHitPoints < 0)
        {
            CameraShake.Instance.ShakeCamera(2f, 0.2f);
            //TODO Reward Screen
            RewardManager.Instance.OnBossKilled(EquipmentLevel + (int)SelectedDifficulty);
            return;
        }
        CameraShake.Instance.ShakeCamera(0.7f, 0.2f);
    }
}
