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
    public const float EasyPercentage = 0.0f;
    public const float MediumPercentage = 0.0f;
    public const float HardPercentage = 0.5f;
    public const float EasyPercentageDebuff = 0.3f;
    public const float MediumPercentageDebuff = 0.5f;
    public const float HardPercentageDebuff = 0.25f;

    private AudioSource _hitSound;

    private bool dead = false;

    public void Awake()
    {
        Enemy = Resources.Load<EnemyScriptableObject>("ScriptableObjects/SelectedBoss");
        CurrentHitPoints = Enemy.MaxHitpoints;
        Damage = Enemy.Damage;
        EquipmentLevel = Enemy.EquipmentLevel;
        SelectedDifficulty = Enemy.Difficulty;
        _hitSound = GetComponent<AudioSource>();
    }
    public void TakeDamage(int damage)
    {
        if (dead) return;
        _hitSound.Play();
        CurrentHitPoints -= CalculateFinalDamage(damage);
        if (CurrentHitPoints <= 0)
        {
            CameraShake.Instance.ShakeCamera(2f, 0.2f);
            //TODO Reward Screen
            GameManager.Instance.OnBossKilled(Enemy);
            dead = true;
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
                return (int)(damage - damage * EasyPercentageDebuff);
            case EnemyDifficulty.Medium:
                return (int)(damage - damage * MediumPercentageDebuff);
            default:
                return (int)(damage - damage * HardPercentageDebuff);
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
