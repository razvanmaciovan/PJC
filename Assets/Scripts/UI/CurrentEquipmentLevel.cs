using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentEquipmentLevel : MonoBehaviour
{
    private const string EL = "Equipment Level: <color=yellow>";
    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        _textMeshProUGUI.text = $"{EL}{DataManager.Instance.GetPlayerEquipmentLevel()}";
    }
}
