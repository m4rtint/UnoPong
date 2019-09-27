//-----------------------------------------------------------------------
// <copyright file="Utilities.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using UnityEngine;
    
    /// <summary>
    /// Utilities class for tools
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// max available players allowed
        /// </summary>
        public const int AvailablePlayers = 4;

        /// <summary>
        /// Converts Index in array To Vector 3
        /// </summary>
        /// <param name="i">index within array</param>
        /// <param name="widthAndHeight">width or height of board</param>
        /// <returns>position of index</returns>
        public static Vector3 IndexToVector(int i, int widthAndHeight)
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
        /// Takes index of board and checks if it's on an edge
        /// </summary>
        /// <param name="i">index on board</param>
        /// <param name="widthAndHeight">width or height of board</param>
        /// <returns>is index on edge</returns>
        public static bool IsIndexOnAnEdge(int i, int widthAndHeight)
        {
            return false;
        }

        /// <summary>
        /// Chooses a random players depending on amount of active players
        /// </summary>
        /// <param name="amountOfPlayers">number of players active</param>
        /// <returns>Chosen Player Enum</returns>
        public static Player RandomPlayer(int amountOfPlayers)
        {
            if (amountOfPlayers > AvailablePlayers)
            {
                throw new System.Exception("Don't try to randomly generating more players than needed");
            }

            return (Player)Random.Range(0, amountOfPlayers);
        }
    }
}
