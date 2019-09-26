//-----------------------------------------------------------------------
// <copyright file="SimpleCameraShake.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using Cinemachine;
    using UnityEngine;

    /// <summary>
    /// Camera Shaker script
    /// </summary>
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class SimpleCameraShake : MonoBehaviour
    {
        private static SimpleCameraShake _instance;
        [SerializeField]
        private float shakeDuration = 0.3f;
        [SerializeField]
        private float shakeAmplitude = 1.2f;
        [SerializeField] 
        private float shakeFrequency = 0f;

        private float shakeElapsedTime = 0f;

        private CinemachineVirtualCamera _virtualCamera;
        private CinemachineBasicMultiChannelPerlin _virtualCameraNoise;

        /// <summary>
        /// Gets global instance to access like singleton
        /// </summary>
        public static SimpleCameraShake Instance
        {
            get
            {
                return _instance;
            }
        }

        private bool IsShaking
        {
            get
            {
                return shakeElapsedTime > 0;
            }
        }

        /// <summary>
        /// Shake camera for duration
        /// </summary>
        public void PlayShake()
        {
            shakeElapsedTime = shakeDuration;
        }

        private void Update()
        {
            if (_virtualCamera != null || _virtualCameraNoise != null)
            {
                if (IsShaking)
                {
                    shakeElapsedTime -= Time.deltaTime;

                    if (shakeElapsedTime > 0)
                    {
                        _virtualCameraNoise.m_AmplitudeGain = shakeAmplitude;
                        _virtualCameraNoise.m_FrequencyGain = shakeFrequency;
                    }
                    else
                    {
                        _virtualCameraNoise.m_AmplitudeGain = 0;
                        shakeElapsedTime = 0;
                    }
                }
            }
        }

        private void Awake()
        {
            if (_virtualCamera == null)
            {
                _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            }

            if (_instance == null)
            {
                _instance = this;
            }
        }

        private void Start()
        {
            if (_virtualCamera != null)
            {
                _virtualCameraNoise = _virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
            }
        }
    }
}