using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBossDefeat : MonoBehaviour
{
    private Animator _animator;
    private bool _isPlayerCamera = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void OnBossKilled()
    {
        _animator.Play(_isPlayerCamera ? "BossCamera" : "PlayerCamera");
        _isPlayerCamera = !_isPlayerCamera;
    }
}
