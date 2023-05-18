using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossDeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject _bossDefeat;

    public GameObject Continue;

    public GameObject Reward;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BossDefeat());
    }

    private IEnumerator BossDefeat()
    {
        yield return new WaitForSeconds(2);
        _bossDefeat.SetActive(true);
        yield return new WaitForSeconds(2);
        Continue.SetActive(true);
        Reward.SetActive(true);

    }

}
