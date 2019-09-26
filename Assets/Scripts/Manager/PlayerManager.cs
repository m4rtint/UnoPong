namespace MPHT {
    using System;
    using UnityEngine;
    using UnityEngine.Assertions;

    public class PlayerManager : MonoBehaviour
    {
        private PlayerPlatform[] _arrayOfPlayerPlatforms;
        private readonly PlayerManagerBehaivour _behavior = new PlayerManagerBehaivour();

        /// <summary>
        /// Activate the specific player
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player, Direction direction)
        {
            PlayerPlatform playerPlat = _arrayOfPlayerPlatforms[(int)player];
            playerPlat.transform.position = _behavior.PlatformInitialPosition(direction);


        }

        private void Awake()
        {
            SetupPlayerPlatform();
            _behavior.CheckPlayerAvailabilityCount(_arrayOfPlayerPlatforms);
        }

        private void SetupPlayerPlatform()
        {
            _arrayOfPlayerPlatforms = GetComponentsInChildren<PlayerPlatform>();
        }
    }

    public class PlayerManagerBehaivour {
        bool[] _directionsTaken = new bool[Enum.GetValues(typeof(Direction)).Length];

        public void CheckPlayerAvailabilityCount(PlayerPlatform[] platforms)
        {
            if (platforms.Length != MPHT.Utilities.AvailablePlayers)
            {
                throw new Exception($"Amount of platforms in child MUST equal {MPHT.Utilities.AvailablePlayers}");
            }
        }

        /// <summary>
        /// Return the initial position of platforms depending on direction
        /// </summary>
        /// <param name="dir">Direction of where to start</param>
        /// <returns>position of where the platform starts</returns>
        public Vector3 PlatformInitialPosition(Direction dir)
        {
            return Vector3.zero;
        }
    }

}