//-----------------------------------------------------------------------
// <copyright file="MainMenuManagerBehaviour.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System;
    using UnityEngine;
    using MPHT;

    /// <summary>
    /// Logic for the main menu
    /// </summary>
    public class MainMenuManagerBehaviour
    {
        /// <summary>
        /// Find the opposite direction of given direction
        /// </summary>
        /// <param name="dir">direction given</param>
        /// <returns>opposite direction</returns>
        public Direction OppositeDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.UP:
                    return Direction.DOWN;
                case Direction.LEFT:
                    return Direction.RIGHT;
                case Direction.RIGHT:
                    return Direction.LEFT;
                case Direction.DOWN:
                    return Direction.UP;
                default:
                    return Direction.UP;
            }
        }
    }
}
