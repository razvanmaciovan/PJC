using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FightSelectionUI : MonoBehaviour
{
    private List<EnemyScriptableObject> Bosses;
    public GameObject BossSelectionPrefab;
    public GameObject BossSelectionPlaceholder;
    private void Awake()
    {
        Bosses = Resources.Load<EnemyListScriptableObject>("ScriptableObjects/AvailableBosses").EnemyList;
    }

    private void Start()
    {
        if (BossSelectionPlaceholder.transform.childCount > 0)
        {
            foreach (Transform child in BossSelectionPrefab.transform) {
                Destroy(child.gameObject);
            }
        }
        Bosses.ForEach(b =>
        {
            var bossGameObject = Instantiate(BossSelectionPrefab, BossSelectionPlaceholder.transform);
            var e = bossGameObject.GetComponent<BossSelection>();
            e.Enemy = b;
            e.Init();
        });
    }
}
