using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int CurrentHitPoints = 100;
    [HideInInspector] public int EquipmentLevel;
    [HideInInspector] public int Damage;
    [HideInInspector] public EnemyDifficulty SelectedDifficulty;
    public EnemyScriptableObject Enemy;

    [Header("Bonus damage output")] 
    [Space]
    public const float EasyPercentage = 0.3f;
    public const float MediumPercentage = 0.75f;
    public const float HardPercentage = 1.5f;


    public void Awake()
    {
        CurrentHitPoints = Enemy.MaxHitpoints;
        Damage = Enemy.Damage;
        EquipmentLevel = Enemy.EquipmentLevel;
        SelectedDifficulty = Enemy.Difficulty;
    }
    public void TakeDamage(int damage)
    {
        CurrentHitPoints -= CalculateFinalDamage(damage);
        if (CurrentHitPoints <= 0)
        {
            CameraShake.Instance.ShakeCamera(2f, 0.2f);
            //TODO Reward Screen
            GameManager.Instance.OnBossKilled(Enemy);
            return;
        }
        CameraShake.Instance.ShakeCamera(0.7f, 0.2f);
    }

    private int CalculateFinalDamage(int damage)
    {
        var playerLevel = DataManager.Instance.GetPlayerEquipmentLevel();
        if (playerLevel >= EquipmentLevel) return damage;

        switch (SelectedDifficulty)
        {
            case EnemyDifficulty.Easy:
                return (int)(damage - damage * 0.3);
            case EnemyDifficulty.Medium:
                return (int)(damage - damage * 0.5);
            default:
                return (int)(damage - damage * 0.7);
        }
    }

    public int CalculateDamageToPlayer()
    {
        if (DataManager.Instance.GetPlayerEquipmentLevel() >= EquipmentLevel) return Damage;

        switch (SelectedDifficulty)
        {
            case EnemyDifficulty.Easy:
                return (int)(Damage + Damage * EasyPercentage);
            case EnemyDifficulty.Medium:
                return (int)(Damage + Damage * MediumPercentage);
            default:
                return (int)(Damage + Damage * HardPercentage);
        }
    }
}
