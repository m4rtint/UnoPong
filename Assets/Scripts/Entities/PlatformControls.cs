//-----------------------------------------------------------------------
// <copyright file="PlatformControls.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{ 
    using System.Collections;
    using System.Collections.Generic;
    using MPHT;
    using UnityEngine;

    /// <summary>
    /// Handles movement for platform
    /// </summary>
    public class PlatformControls : MonoBehaviour
    {
        private Rigidbody2D _rigidBody;
        private PlayerPlatform _playerPlat;

        private PlayerPlatform PlayerPlat
        {
            get
            {
                if (_playerPlat == null)
                {
                    _playerPlat = GetComponent<PlayerPlatform>();
                }

                return _playerPlat;
            }
        }

        private Rigidbody2D RigidBody
        {
            get
            {
                if (_rigidBody == null)
                {
                    _rigidBody = GetComponent<Rigidbody2D>();
                }

                return _rigidBody;
            }
        }

        private void Awake()
        {
            WorldManager.OnFixedUpdate += PlatformControlOnUpdate;
        }

        private void OnDestroy()
        {
            WorldManager.OnFixedUpdate -= PlatformControlOnUpdate;
        }

        private void PlatformControlOnUpdate()
        {
            TranslatePlatform();
        }

        private void TranslatePlatform()
        {
            if (MPHT.InputManager.OnHorizontalPressed(PlayerPlat.Input) > 0)
            {
                transform.position += new Vector3(0.3f, 0);
            }
            else if (MPHT.InputManager.OnHorizontalPressed(PlayerPlat.Input) < 0)
            {
                transform.position -= new Vector3(0.3f, 0);
            }
        }
    }
}