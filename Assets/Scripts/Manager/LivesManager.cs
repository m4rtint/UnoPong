//-----------------------------------------------------------------------
// <copyright file="LivesManager.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections.Generic;
    
    /// <summary>
    /// Keeps score of all players
    /// </summary>
    public class LivesManager
    {
        private Dictionary<Player, int> _dictionaryOfPlayerLives;

        /// <summary>
        /// Initializes a new instance of the <see cref="LivesManager" /> class.
        /// </summary>
        /// <param name="dictOfLives">Dictionary of lives</param>
        public LivesManager(int amountOfBricks, int amountOfPlayers) 
        {
        }
    }
}
