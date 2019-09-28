//-----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using UnityEngine;
    
    /// <summary>
    /// Utilities class for tools
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// max available players allowed
        /// </summary>
        public const int AvailablePlayers = 4;

        /// <summary>
        /// Chooses a random players depending on amount of active players
        /// </summary>
        /// <param name="amountOfPlayers">number of players active</param>
        /// <returns>Chosen Player Enum</returns>
        public static Player RandomPlayer(int amountOfPlayers)
        {
            if (amountOfPlayers > AvailablePlayers)
            {
                throw new System.Exception("Don't try to randomly generating more players than needed");
            }

            return (Player)Random.Range(0, amountOfPlayers);
        }
    }
}
