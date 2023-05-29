using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossSelection : MonoBehaviour
{
    public TextMeshProUGUI BossName;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Difficulty;
    public Image BossIcon;
    public EnemyScriptableObject Enemy;

    public void Init()
    {
        BossName.text = Enemy.Name;
        Level.text = Enemy.EquipmentLevel.ToString();
        Difficulty.text = Enemy.Difficulty.ToString().ToUpper();
        BossIcon.sprite = Enemy.Icon;
        if (Enemy.Difficulty == EnemyDifficulty.Easy)
        {
            Difficulty.color = Color.green;
        }
        else if (Enemy.Difficulty == EnemyDifficulty.Medium)
        {
            Difficulty.color = Color.yellow;
        }
        else
        {
            Difficulty.color = Color.red;
        }
    }

    public void SelectBoss()
    {
        var selectedBoss = Resources.Load<EnemyScriptableObject>("ScriptableObjects/SelectedBoss");
        selectedBoss.Difficulty = Enemy.Difficulty;
        selectedBoss.Icon = Enemy.Icon;
        selectedBoss.Damage = Enemy.Damage;
        selectedBoss.EnemyPrefab = Enemy.EnemyPrefab;
        selectedBoss.EquipmentLevel = Enemy.EquipmentLevel;
        selectedBoss.MaxHitpoints = Enemy.MaxHitpoints;
        selectedBoss.Name = Enemy.Name;
        selectedBoss.StartingPositionX = Enemy.StartingPositionX;
        selectedBoss.StartingPositionY = Enemy.StartingPositionY;
        GameManager.Instance.ChangeScene(Enemy.Scene);
    }
}
