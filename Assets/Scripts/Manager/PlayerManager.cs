namespace MPHT {
    using System;
    using UnityEngine;
    using UnityEngine.Assertions;

    public class PlayerManager : MonoBehaviour
    {
        private const int _availablePlayers = 4;
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
            Assert.AreEqual<int>(_arrayOfPlayerPlatforms.Length, _availablePlayers, $"Amount of platforms in child MUST equal {_availablePlayers}");
        }
    }

}