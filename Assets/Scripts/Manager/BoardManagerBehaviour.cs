﻿//-----------------------------------------------------------------------
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
        /// Converts Index in array To Vector 3
        /// </summary>
        /// <param name="i">index within array</param>
        /// <param name="widthAndHeight">width or height of board</param>
        /// <returns>position of index</returns>
        public Vector3 IndexToVector(int i, int widthAndHeight)
        {
            Vector3 position = Vector3.zero;

            if (i < 0)
            {
                return position;
            }

            if (i < widthAndHeight * widthAndHeight)
            {
                position.x = ((i % widthAndHeight) * 0.5f) - 3f;
                position.y = (Mathf.Floor(i / widthAndHeight) * -0.5f) + 3f;
            }

            return position;
        }

        /// <summary>
        /// Returns the bricks which would make an outline of the shape
        /// </summary>
        /// <param name="boardTemplate">template of board</param>
        /// <param name="width">width of board</param>
        /// <returns>array of the outlined bricks</returns>
        public bool[] OutlinedBricks(bool[] boardTemplate, int width)
        {
            // TODO
            return boardTemplate;
        }
    }
}