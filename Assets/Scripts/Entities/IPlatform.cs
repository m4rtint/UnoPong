//-----------------------------------------------------------------------
// <copyright file="IPlatform.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using MPHT;
    using UnityEngine;

    /// <summary>
    /// For testing purposes interface for platform player
    /// </summary>
    public interface IPlatform
    {
        /// <summary>
        /// Gets the direction
        /// </summary>
        Direction Direction { get; }

        /// <summary>
        /// Gets the player
        /// </summary>
        Player Player { get; }

        /// <summary>
        /// Initialized the platform
        /// </summary>
        /// <param name="position">position of where the platform will be</param>
        /// <param name="rotation">rotation of platform</param>
        /// <param name="direction">which side will platform be at</param>
        /// <param name="player">which player number</param>
        /// <param name="mat">material of player</param>
        /// <param name="placement">which keys allow input</param>
        void Initialize(Vector3 position, Quaternion rotation, Direction direction, Player player, Material mat, ControlScheme placement);
    }
}