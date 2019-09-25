namespace MPHT {
    using System;
    using UnityEngine;
    using UnityEngine.Assertions;
    using MPHT;

    public class PlayerManager : MonoBehaviour
    {
        private PlayerPlatform[] _arrayOfPlayerPlatforms;
        private readonly PlayerManagerBehaivour _behavior = new PlayerManagerBehaivour();

        /// <summary>
        /// Activate the specific player
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(Player player)
        {

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

        public void CheckPlayerAvailabilityCount(PlayerPlatform[] platforms)
        {
            if (platforms.Length != MPHT.Utilities.AvailablePlayers)
            {
                throw new Exception($"Amount of platforms in child MUST equal {MPHT.Utilities.AvailablePlayers}");
            }
        }
    }

}