//-----------------------------------------------------------------------
// <copyright file="StateManager.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// State of game
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Before the game starts
        /// </summary>
        PREGAME,

        /// <summary>
        /// While the game is running
        /// </summary>
        GAME,

        /// <summary>
        /// Game is paused
        /// </summary>
        PAUSE,

        /// <summary>
        /// End of game
        /// </summary>
        ENDGAME
    }

    /// <summary>
    /// Manages the current state of the game
    /// </summary>
    public static class StateManager
    {
        private static State _state = State.PREGAME;

        /// <summary>
        /// Property to return the state
        /// </summary>
        public static State State => _state;

        /// <summary>
        /// Sets the state to play game
        /// </summary>
        public static void PlayGame()
        {
            _state = State.GAME;
        }

        /// <summary>
        /// Checks if current state is playing the game
        /// </summary>
        /// <returns>is in game</returns>
        public static bool IsInGame()
        {
            return _state == State.GAME;
        }

        /// <summary>
        /// Checks if the game is paused
        /// </summary>
        /// <returns>is paused</returns>
        public static bool IsPaused()
        {
            return _state == State.PAUSE;
        }
    }
}
