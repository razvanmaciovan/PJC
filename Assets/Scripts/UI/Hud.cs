using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityTypes;

public class Hud : MonoBehaviour
{
    public TextMeshProUGUI PlayerHp;
    public TextMeshProUGUI BossHp;
    public Slider PlayerHpSlider;
    public Slider EnemyHpSlider;
    private PlayerController playerController;
    private EnemyController enemyController;
    public TextMeshProUGUI BossName;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag(UnityTags.Player.ToString())
            .GetComponent<PlayerController>();
        enemyController =  GameObject.FindGameObjectWithTag(UnityTags.Enemy.ToString())
            .GetComponent<EnemyController>();
        PlayerHpSlider.maxValue = playerController.Health;
        EnemyHpSlider.maxValue = enemyController.CurrentHitPoints;
        BossName.text = enemyController.Enemy.Name;
    }

    private void Update()
    {
        PlayerHp.text = playerController.Health.ToString();
        BossHp.text = enemyController.CurrentHitPoints.ToString();
        PlayerHpSlider.value = playerController.Health;
        EnemyHpSlider.value = enemyController.CurrentHitPoints;

    }
}
