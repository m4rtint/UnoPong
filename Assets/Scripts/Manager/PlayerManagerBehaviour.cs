//-----------------------------------------------------------------------
// <copyright file="PlayerManagerBehaviour.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System;
    using UnityEngine;
    using UnityEngine.Assertions;

    /// <summary>
    /// Logic for Player Manager
    /// </summary>
    public class PlayerManagerBehaviour
    {
        private readonly IMaterials _playerMaterials;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerManagerBehaviour" /> class
        /// </summary>
        /// <param name="playerMaterials">Player Materials loader</param>
        public PlayerManagerBehaviour(IMaterials playerMaterials)
        {
            this._playerMaterials = playerMaterials;
        }

        /// <summary>
        /// Checks if the number of platforms obtained is correct
        /// </summary>
        /// <param name="platforms">array of all platforms</param>
        public void CheckPlayerAvailabilityCount(IPlatform[] platforms)
        {
            if (platforms.Length != MPHT.Utilities.AvailablePlayers)
            {
                throw new Exception($"Amount of platforms in child MUST equal {MPHT.Utilities.AvailablePlayers}");
            }
        }

        /// <summary>
        /// Initializes the platform properties
        /// </summary>
        /// <param name="platform">Platform object</param>
        /// <param name="dir">Direction of where platform should start at</param>
        /// <param name="player">Player Number</param>
        /// <param name="placement">Keyboard control scheme</param>
        public void PlatformInitialize(IPlatform platform, Direction dir, Player player, ControlScheme placement)
        {
            Vector3 position = this.GetPositionFromDirection(dir);
            Quaternion rotation = this.GetRotationFromDirection(dir);
            Material playerColor = this._playerMaterials.GetPlayerMaterialFor(player);

            platform.Initialize(position, rotation, dir, player, playerColor, placement);
        }

        /// <summary>
        /// Gets the Quaternion rotation value from the direction chosen
        /// </summary>
        /// <param name="dir">direction chosen to spawn at</param>
        /// <returns>Quaternion angle to spawn</returns>
        public Quaternion GetRotationFromDirection(Direction dir)
        {
            Quaternion rotation = Quaternion.identity;
            if (dir == Direction.RIGHT || dir == Direction.LEFT)
            {
                rotation = Quaternion.Euler(0, 0, 90);
            }

            return rotation;
        }

        /// <summary>
        /// Gets the position vector from the direction chosen
        /// </summary>
        /// <param name="dir">direction chosen to spawn at</param>
        /// <returns>Position to spawn at</returns>
        public Vector3 GetPositionFromDirection(Direction dir)
        {
            Vector3 position = Vector3.zero;
            switch (dir)
            {
                case Direction.UP:
                    position.y = 4;
                    break;
                case Direction.DOWN:
                    position.y = -4;
                    break;
                case Direction.LEFT:
                    position.x = -4;
                    break;
                case Direction.RIGHT:
                    position.x = 4;
                    break;
            }

            return position;
        }
    }
}