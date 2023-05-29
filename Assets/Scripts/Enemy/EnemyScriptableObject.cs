using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityTypes;

[CreateAssetMenu(fileName = "Boss", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    public string Name;
    public int EquipmentLevel;
    public int Damage;
    public int MaxHitpoints;
    public EnemyDifficulty Difficulty;
    public GameObject EnemyPrefab;
    public float StartingPositionX;
    public float StartingPositionY;
    public UnityScenes Scene;
    public Sprite Icon;
}
