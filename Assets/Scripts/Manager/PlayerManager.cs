//-----------------------------------------------------------------------
// <copyright file="PlayerManager.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System;
    using UnityEngine;
    using UnityEngine.Assertions;
    using MPHT;

    /// <summary>
    /// Manages all players - platforms
    /// </summary>
    public class PlayerManager : MonoBehaviour
    {
        private IPlatform[] _arrayOfPlayerPlatforms;
        private PlayerManagerBehaviour _behaviour;

        /// <summary>
        /// Activate the specific player
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player, Direction direction, InputPlacement placement)
        {
            IPlatform playerPlat = _arrayOfPlayerPlatforms[(int)player];
            _behaviour.PlatformInitialize(playerPlat, direction, player, placement);
        }

        public void Initialize(PlayerMaterials playerMaterials)
        {
            _behaviour = new PlayerManagerBehaviour(playerMaterials);
            SetupPlayerPlatform();
            _behaviour.CheckPlayerAvailabilityCount(_arrayOfPlayerPlatforms);
        }

        private void SetupPlayerPlatform()
        {
            _arrayOfPlayerPlatforms = GetComponentsInChildren<IPlatform>();
        }
    }
}