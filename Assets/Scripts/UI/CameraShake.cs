using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance { get; set; }

    private CinemachineVirtualCamera _virtualCamera;
    private float _shakeTimer;
    private void Awake()
    {
        Instance = this; 
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void ShakeCamera(float intensity, float timer)
    {
        var cinemachineBasicMultiChannelPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        _shakeTimer = timer;

    }
    private void Update()
    {
        if(_shakeTimer > 0)
        {
            _shakeTimer-=Time.deltaTime;
            if(_shakeTimer < 0)
            {
                var cinemachineBasicMultiChannelPerlin = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}