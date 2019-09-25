namespace MPHT {
    using System;
    using UnityEngine;
    using UnityEngine.Assertions;
    using MPHT;

    public class PlayerManager : MonoBehaviour
    {
        private PlayerPlatform[] _arrayOfPlayerPlatforms;

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
        }

        private void SetupPlayerPlatform()
        {
            _arrayOfPlayerPlatforms = GetComponentsInChildren<PlayerPlatform>();
            Assert.AreEqual<int>(_arrayOfPlayerPlatforms.Length, MPHT.Utilities.AvailablePlayers, $"Amount of platforms in child MUST equal {MPHT.Utilities.AvailablePlayers}");
        }
    }

}