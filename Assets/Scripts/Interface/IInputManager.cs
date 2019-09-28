//-----------------------------------------------------------------------
// <copyright file="IInputManager.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Interface for mocking input manager
    /// </summary>
    public interface IInputManager
    {
        /// <summary>
        /// Checks if any key is pressed
        /// </summary>
        /// <returns>any key is pressed</returns>
        KeyCode IsAnyKeyBeingPressed();

        /// <summary>
        /// is any key on specific axis is pressed
        /// </summary>
        /// <param name="isHorizontalAvailable">which axis</param>
        /// <returns>key of given axis</returns>
        KeyCode IsKeyBeingPressOnAxis(bool isHorizontalAvailable);

        /// <summary>
        /// Is key being pressed on specific direction
        /// </summary>
        /// <param name="dir">direction of key</param>
        /// <returns>key code for direction</returns>
        KeyCode IsKeyBeingPressedAt(Direction dir);

        /// <summary>
        /// Direction of key code given
        /// </summary>
        /// <param name="key">key code</param>
        /// <returns>direction of key</returns>
        Direction GetDirectionFromKeyCode(KeyCode key);

        /// <summary>
        /// Control scheme belonged to key
        /// </summary>
        /// <param name="key">key code</param>
        /// <returns>control scheme</returns>
        ControlScheme GetSchemeFromKeyCode(KeyCode key);
    }
}