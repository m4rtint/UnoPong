﻿namespace MPHT {
    using System;
    using UnityEngine;
    using UnityEngine.Assertions;

    public class PlayerManager : MonoBehaviour
    {
        private IPlatform[] _arrayOfPlayerPlatforms;
        private PlayerManagerBehaviour _behaviour;

        /// <summary>
        /// Activate the specific player
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player, Direction direction)
        {
            IPlatform playerPlat = _arrayOfPlayerPlatforms[(int)player];
            _behaviour.PlatformInitialize(playerPlat, direction, player);
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

    public class PlayerManagerBehaviour {

        private readonly IMaterials _playerMaterials;

        bool[] _directionsTaken = new bool[Enum.GetValues(typeof(Direction)).Length];

        /// <summary>
        /// Constructor for play manager behaviour
        /// </summary>
        /// <param name="playerMaterials">Player Materials loader</param>
        public PlayerManagerBehaviour(IMaterials playerMaterials)
        {
            _playerMaterials = playerMaterials;
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
        public void PlatformInitialize(IPlatform platform, Direction dir, Player player)
        {
            // TODO - Set the position/orientation;
            Vector3 position = GetPositionFromDirection(dir);
            Quaternion rotation = GetRotationFromDirection(dir);
            // TODO - Set the material;
            Material playerColor = _playerMaterials.GetPlayerMaterialFor(player);

            platform.Initialize(position, rotation, dir, player, playerColor);

            // TODO - Set the Controls
        }

        public Quaternion GetRotationFromDirection(Direction dir)
        {
            Quaternion rotation = Quaternion.identity;
            if (dir == Direction.RIGHT || dir == Direction.LEFT) {
                rotation = Quaternion.Euler(0, 0, 90);
            }

            return rotation;
        }

        public Vector3 GetPositionFromDirection(Direction dir)
        {
            Vector3 position = Vector3.zero;
            switch(dir)
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