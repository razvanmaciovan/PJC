using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub : MonoBehaviour
{
    public GameObject GearSelectionUi;
    public GameObject BossSelectionUi;

    private void Awake()
    {
        BossToGear();
    }
    public void GearToBoss()
    {
        GearSelectionUi.SetActive(false);
        BossSelectionUi.SetActive(true);
    }

    public void BossToGear()
    {
        GearSelectionUi.SetActive(true);
        BossSelectionUi.SetActive(false);

    }
}
