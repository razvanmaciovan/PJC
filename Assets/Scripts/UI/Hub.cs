using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub : MonoBehaviour
{
    public GameObject GearSelectionUi;
    public GameObject BossSelectionUi;
    public GameObject PlayerGameObject;

    private void Awake()
    {
        BossToGear();
    }
    public void GearToBoss()
    {
        GearSelectionUi.SetActive(false);
        BossSelectionUi.SetActive(true);
        PlayerGameObject.SetActive(false);
    }

    public void BossToGear()
    {
        GearSelectionUi.SetActive(true);
        BossSelectionUi.SetActive(false);
        PlayerGameObject.SetActive(true);

    }
}
