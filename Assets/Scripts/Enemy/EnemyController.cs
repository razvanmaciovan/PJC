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
        if (CurrentHitPoints < damage)
        {
            //TODO Death Anim
            //TODO Reward Screen
            RewardManager.Instance.OnBossKilled(EquipmentLevel + (int)SelectedDifficulty);
            print("DEAD");
            return;
        }

        CurrentHitPoints -= damage;
        GetComponent<Animator>().SetTrigger("Hit");
        CameraShake.Instance.ShakeCamera(0.7f, 0.2f);
    }
}
