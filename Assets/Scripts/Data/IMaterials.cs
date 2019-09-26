//-----------------------------------------------------------------------
// <copyright file="IMaterials.cs" company="Martin Pak Hei Tsang">
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
    /// Interface for Materials - used for testing
    /// </summary>
    public interface IMaterials
    {
        /// <summary>
        /// Gets the material dedicated for specific player
        /// </summary>
        /// <param name="player">Player Number</param>
        /// <returns>Material for player</returns>
        Material GetPlayerMaterialFor(Player player);
    }
}