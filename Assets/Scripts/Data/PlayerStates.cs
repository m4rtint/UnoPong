//-----------------------------------------------------------------------
// <copyright file="PlayerStates.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------

namespace MPHT
{
    /// <summary>
    /// Player Number
    /// </summary>
    public enum Player
    {
        /// <summary>
        /// Player One
        /// </summary>
        PLAYER_ONE,

        /// <summary>
        /// Player Two
        /// </summary>
        PLAYER_TWO,

        /// <summary>
        /// Player Three
        /// </summary>
        PLAYER_THREE,

        /// <summary>
        /// Player Four
        /// </summary>
        PLAYER_FOUR
    }

    /// <summary>
    /// Direction of platform/player
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// Down Position
        /// </summary>
        DOWN,

        /// <summary>
        /// Up Position
        /// </summary>
        UP,

        /// <summary>
        /// Left Position
        /// </summary>
        LEFT,

        /// <summary>
        /// Right Position
        /// </summary>
        RIGHT
    }
}