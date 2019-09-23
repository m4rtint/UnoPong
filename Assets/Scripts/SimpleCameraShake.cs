using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class SimpleCameraShake : MonoBehaviour
{
    [SerializeField]
    private float shakeDuration = 0.3f;
    [SerializeField]
    private float shakeAmplitude = 1.2f;
    [SerializeField]
    private float shakeFrequency = 0f;

    private float shakeElapsedTime = 0f;
    private bool IsShaking
    {
        get
        {
            return shakeElapsedTime > 0;
        }
    }

    public static SimpleCameraShake instance;

    //Cinemachine shake
    private CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    private void Awake()
    {
        if (virtualCamera == null)
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        if (virtualCamera != null)
        {
            virtualCameraNoise = virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }
    }

    public void PlayShake()
    {
        shakeElapsedTime = shakeDuration;
    }

    private void Update()
    {
        if (virtualCamera != null || virtualCameraNoise != null) {
            if (IsShaking)
            {
                shakeElapsedTime -= Time.deltaTime;

                if (shakeElapsedTime > 0)
                {
                    virtualCameraNoise.m_AmplitudeGain = shakeAmplitude;
                    virtualCameraNoise.m_FrequencyGain = shakeFrequency;
                }
                else
                {
                    virtualCameraNoise.m_AmplitudeGain = 0;
                    shakeElapsedTime = 0;
                }
            }
        }
    }
}
