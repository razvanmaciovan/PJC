using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityTypes;

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
        Continue.GetComponent<Button>().onClick.AddListener(continueClicked);
        if (RewardManager.Instance.LastReward != String.Empty)
        {
            Reward.SetActive(true);
            Reward.GetComponentInChildren<TextMeshProUGUI>().text = "You have received: \n" + RewardManager.Instance.LastReward;
        }
    }

    public void continueClicked()
    {
        GameManager.Instance.ChangeScene(UnityScenes.Hub);
    }
}
