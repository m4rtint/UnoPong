//-----------------------------------------------------------------------
// <copyright file="MainMenuManagerBehaviour.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using MPHT;

    /// <summary>
    /// Logic for the main menu
    /// </summary>
    public class MainMenuManagerBehaviour
    {
        private HashSet<Direction> _setOfTakenDirections = new HashSet<Direction>();

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

        /// <summary>
        /// Which Direction start buttons to deactivate depending on state
        /// </summary>
        /// <param name="direction">Direction that was picked</param>
        /// <returns>Set of Direction to deactivate</returns>
        public HashSet<Direction> DirectionToDeactivate(Direction direction)
        {
            HashSet<Direction> directions = new HashSet<Direction>() { Direction.UP, Direction.DOWN, Direction.LEFT, Direction.RIGHT };
            _setOfTakenDirections.Add(direction);

            if (_setOfTakenDirections.Count == 1)
            {
                directions.Remove(OppositeDirection(direction));
            }
            else
            {
                directions.IntersectWith(_setOfTakenDirections);
            }

            return directions;
        }
     
    }
}
