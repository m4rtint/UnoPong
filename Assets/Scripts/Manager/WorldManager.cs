//-----------------------------------------------------------------------
// <copyright file="WorldManager.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using MPHT;
    using UnityEngine;

    /// <summary>
    /// First Manager to be called, handles game as a whole
    /// </summary>
    [RequireComponent(typeof(PlayerMaterials))]
    public class WorldManager : MonoBehaviour
    {
        //// TODO - Placeholder
        private static int _numberOfPlayers = 2;
        [Header("Managers")]
        [SerializeField]
        private BoardManager _boardManager;
        [SerializeField]
        private PlayerManager _playerManager;
        [SerializeField]
        private MainMenuManager _mainMenuManager;
        private PlayerMaterials _playerMaterial;
        
        /// <summary>
        /// Called on every fixed update. All classes should be based on this
        /// </summary>
        public static event Action OnFixedUpdate;

        private PlayerMaterials PlayerMaterial
        {
            get
            {
                if (_playerMaterial == null)
                {
                    _playerMaterial = GetComponent<PlayerMaterials>();
                }

                return _playerMaterial;
            }
        }

        private void Awake()
        {
            _mainMenuManager.OnPlayerSelected += PlayerSelected;
            _playerManager.Initialize(PlayerMaterial);
        }

        private void OnStartGame()
        {
            //// _boardManager.Initialize(BoardTemplates.BoardThree, _numberOfPlayers, PlayerMaterial);
        }

        private void OnDestroy()
        {
            _mainMenuManager.OnPlayerSelected -= PlayerSelected;
        }

        private void FixedUpdate()
        {
            OnFixedUpdate?.Invoke();
        }

        private void PlayerSelected(Player player, Direction direction, ControlScheme scheme)
        {
            _playerManager.AddPlayer(player, direction, scheme);
        }
    }
}