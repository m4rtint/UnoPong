//-----------------------------------------------------------------------
// <copyright file="BoardManagerBehaviour.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Board Manager logic
    /// </summary>
    public class BoardManagerBehaviour
    {
        /// <summary>
        /// Checks if the template board brick amount matches the amount of bricks on the scene
        /// </summary>
        /// <param name="boardTemplate">template for board</param>
        /// <param name="board">board on the scene</param>
        public void CheckTemplate(bool[] boardTemplate, GameObject[] board)
        {
            if (boardTemplate.Length != board.Length)
            {
                throw new System.Exception($"Board template amount not exact: board has {board.Length} bricks, template has {boardTemplate.Length} bricks");
            }
        }

        /// <summary>
        /// Returns the bricks which would make an outline of the shape
        /// </summary>
        /// <param name="boardTemplate">template of the board</param>
        /// <returns>outlined shape of the board</returns>
        public bool[] BoardOutlinedBricks(bool[] boardTemplate, int width)
        {
            // TODO
            return boardTemplate;
        }
    }
}