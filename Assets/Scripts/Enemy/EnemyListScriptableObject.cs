using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossList", menuName = "ScriptableObjects/EnemyList")]
public class EnemyListScriptableObject : ScriptableObject
{
    public List<EnemyScriptableObject> EnemyList;
}
