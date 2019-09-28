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
		private const float amount = 0.3f;
		private Rigidbody2D _rigidBody;
        private PlayerPlatform _playerPlat;
        private PlatformControlsBehaviour _behaviour = new PlatformControlsBehaviour();
        private bool _allowMovement = false;

        /// <summary>
        /// Gets or Sets Allow or disallow movement for the platform
        /// </summary>
        public bool AllowMovement
        {
            get => _allowMovement;
            set => _allowMovement = value;
        }

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
            if (AllowMovement)
            {
                transform.position += _behaviour.PlayerMovement(PlayerPlat, amount);
                transform.position = _behaviour.ClampedPosition(PlayerPlat, transform.position);
            }
        }
    }
}