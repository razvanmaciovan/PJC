using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBossDefeat : MonoBehaviour
{
    public GameObject DeathBackground;
    private Animator _animator;
    private bool _isPlayerCamera = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void OnBossKilled()
    {
        _animator.Play(_isPlayerCamera ? "BossCamera" : "PlayerCamera");
        if(_isPlayerCamera) DeathBackground.SetActive(true);
        _isPlayerCamera = !_isPlayerCamera;
    }
}
