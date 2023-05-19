using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityTypes;

public class Hud : MonoBehaviour
{
    public TextMeshProUGUI PlayerHp;
    public TextMeshProUGUI BossHp;

    private PlayerController playerController;
    private EnemyController enemyController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag(UnityTags.Player.ToString())
            .GetComponent<PlayerController>();
        enemyController =  GameObject.FindGameObjectWithTag(UnityTags.Enemy.ToString())
            .GetComponent<EnemyController>();
    }

    private void Update()
    {
        PlayerHp.text = playerController.Health.ToString();
        BossHp.text = enemyController.CurrentHitPoints.ToString();

    }
}
