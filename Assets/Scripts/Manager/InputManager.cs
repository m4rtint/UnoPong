//-----------------------------------------------------------------------
// <copyright file="InputManager.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Which Control scheme user is using
    /// </summary>
    public enum InputPlacement
    {
        /// <summary>
        /// WASD Contols
        /// </summary>
        WASD,

        /// <summary>
        /// YGHJ Contols
        /// </summary>
        YGHJ,

        /// <summary>
        /// PL:" Controls
        /// </summary>
        PL,

        /// <summary>
        /// Arrow key controls
        /// </summary>
        KEYS
    }

    /// <summary>
    /// Manages all input
    /// </summary>
    public class InputManager
    {
        private const string _WASD = "WASD";
        private const string _YGHJ = "YGHJ";
        private const string _PL = "PL";
        private const string _KEY = "KEYS";

        private const string _Horizontal = "_Horizontal";
        private const string _Vertical = "_Vertical";

        /// <summary>
        /// Check if the horizontal keys are pressed
        /// </summary>
        /// <param name="placement">control scheme</param>
        /// <returns>axis value</returns>
        public static float OnHorizontalPressed(InputPlacement placement)
        {
            return OnKeysPressed(placement, true);
        }

        /// <summary>
        /// Check if the vertical keys are pressed
        /// </summary>
        /// <param name="placement">control scheme</param>
        /// <returns>axis value</returns>
        public static float OnVerticalPressed(InputPlacement placement)
        {
            return OnKeysPressed(placement, false);
        }

        //// TODO - Testing
        private static float OnKeysPressed(InputPlacement placement, bool isHorizontal)
        {
            string axisName = string.Empty;
            switch (placement)
            {
                case InputPlacement.WASD:
                    axisName = _WASD;
                    break;
                case InputPlacement.YGHJ:
                    axisName = _YGHJ;
                    break;
                case InputPlacement.PL:
                    axisName = _PL;
                    break;
                case InputPlacement.KEYS:
                    axisName = _KEY;
                    break;
            }

            string axis = isHorizontal ? _Horizontal : _Vertical;
            return (axisName.Length == 0) ? 0 : Input.GetAxis(axisName + axis);
        }
    }
}
