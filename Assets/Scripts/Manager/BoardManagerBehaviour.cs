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
            int numberOfBricks = 0;
            foreach(bool b in boardTemplate)
            {
                if (b)
                {
                    numberOfBricks++;
                }
            }

            int remainder = numberOfBricks % 13;
            if (remainder != 0 || numberOfBricks == 0)
            {
                throw new System.Exception($"Board template amount not divisible by 13: board has {remainder} too much, or {13 - remainder} too little");
            }

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
            int numBricks = width * width;
            bool[] outlinedBricks = new bool[numBricks];
            // Go through array of board template
            // If the bricks are at the edge of the board, they are automatically an outline square
            // Check the values of the squares directly above, to the right, below, to the left of the square
            // If any of them is false, that square is an outline square
            for (int i = 0; i < numBricks; i++)
            {
                if (// current brick
                    boardTemplate[i] &&
                    // top edge 
                    (i - width <= 0 ||
                    // left edge 
                    i  % width == 0 ||
                    // right edge 
                    i % width == width - 1 ||
                    // bottom edge 
                    i + width >= numBricks ||
                    // brick above current brick
                    (i - width > 0 && !boardTemplate[i - width]) ||
                    // brick to the left of current brick
                    (i - 1 > 0 && !boardTemplate[i - 1]) ||
                    // brick to the right of current brick 
                    (i + 1 < numBricks && !boardTemplate[i + 1]) ||
                    // brick below current brick 
                    (i + width < numBricks && !boardTemplate[i + width])))
                {
                    outlinedBricks[i] = true;
                }
            }
            return outlinedBricks;
        }

    }
}