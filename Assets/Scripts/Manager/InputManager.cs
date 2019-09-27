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
    public enum ControlScheme
    {
        /// <summary>
        /// WASD Controls
        /// </summary>
        WASD,

        /// <summary>
        /// YGHJ Controls
        /// </summary>
        YGHJ,

        /// <summary>
        /// PL:" Controls
        /// </summary>
        PL,

        /// <summary>
        /// Arrow key controls
        /// </summary>
        KEYS,

        /// <summary>
        /// No Controls
        /// </summary>
        NONE,
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

        private static List<KeyCode> _UpKeys = new List<KeyCode>() { KeyCode.W, KeyCode.Y, KeyCode.P, KeyCode.UpArrow };
        private static List<KeyCode> _DownKeys = new List<KeyCode>() { KeyCode.S, KeyCode.H, KeyCode.Semicolon, KeyCode.DownArrow };
        private static List<KeyCode> _LeftKeys = new List<KeyCode>() { KeyCode.A, KeyCode.G, KeyCode.L, KeyCode.LeftArrow };
        private static List<KeyCode> _RightKeys = new List<KeyCode>() { KeyCode.D, KeyCode.J, KeyCode.Quote, KeyCode.RightArrow };

        /// <summary>
        /// Check if the horizontal keys are pressed
        /// </summary>
        /// <param name="placement">control scheme</param>
        /// <returns>axis value</returns>
        public static float OnHorizontalPressed(ControlScheme placement)
        {
            return OnKeysPressed(placement, true);
        }

        /// <summary>
        /// Check if the vertical keys are pressed
        /// </summary>
        /// <param name="placement">control scheme</param>
        /// <returns>axis value</returns>
        public static float OnVerticalPressed(ControlScheme placement)
        {
            return OnKeysPressed(placement, false);
        }

        /// <summary>
        /// Checks which key is being pressed
        /// </summary>
        /// <returns>Control Scheme</returns>
        public static KeyCode IsAnyKeyBeingPressed()
        {
            KeyCode key = KeyCode.None;
            key = IsKeyBeingPressOnAxis(true);
            if (key != KeyCode.None)
            {
                return key;
            }

            key = IsKeyBeingPressOnAxis(false);
            return key;
        }

        /// <summary>
        /// Is Key Code Being Pressed at specific direction
        /// </summary>
        /// <param name="direction">Direction being pressed</param>
        /// <returns>Key that is pressed</returns>
        public static KeyCode IsKeyBeingPressedAt(Direction direction)
        {
            KeyCode key = KeyCode.None;
            switch (direction)
            {
                case Direction.UP:
                    return IsUpBeingPressed();
                case Direction.DOWN:
                    return IsDownBeingPressed();
                case Direction.LEFT:
                    return IsLeftBeingPressed();
                case Direction.RIGHT:
                    return IsRightBeingPressed();
            }

            return key;
        }

        /// <summary>
        /// Checks either axis if the keys are being pressed
        /// </summary>
        /// <param name="isHorizontalAxis">Is checking Horizontal Axis</param>
        /// <returns>KeyCode being pressed</returns>
        public static KeyCode IsKeyBeingPressOnAxis(bool isHorizontalAxis)
        {
            KeyCode key = KeyCode.None;
            if (isHorizontalAxis)
            {
                key = IsLeftBeingPressed();
                if (key != KeyCode.None)
                {
                    return key;
                }

                key = IsRightBeingPressed();
            }
            else
            {
                key = IsUpBeingPressed();
                if (key != KeyCode.None)
                {
                    return key;
                }

                key = IsDownBeingPressed();
            }

            return key;
        }

        /// <summary>
        /// Get Control scheme from key code
        /// </summary>
        /// <param name="key">key code</param>
        /// <returns>Control scheme</returns>
        public static ControlScheme GetSchemeFromKeyCode(KeyCode key)
        {
            if (key == KeyCode.A || key == KeyCode.W || key == KeyCode.S || key == KeyCode.D)
            {
                return ControlScheme.WASD;
            }
            else if (key == KeyCode.Y || key == KeyCode.G || key == KeyCode.H || key == KeyCode.J)
            {
                return ControlScheme.YGHJ;
            }
            else if (key == KeyCode.P || key == KeyCode.L || key == KeyCode.Semicolon || key == KeyCode.Quote)
            {
                return ControlScheme.PL;
            }
            else if (key == KeyCode.UpArrow || key == KeyCode.DownArrow || key == KeyCode.LeftArrow || key == KeyCode.RightArrow)
            {
                return ControlScheme.KEYS;
            }
            else
            {
                return ControlScheme.NONE;
            }
        }

        /// <summary>
        /// Get Direction from key code
        /// </summary>
        /// <param name="key">key code</param>
        /// <returns>Direction of key</returns>
        public static Direction GetDirectionFromKeyCode(KeyCode key)
        {
            if (_UpKeys.Contains(key))
            {
                return Direction.UP;
            }

            if (_DownKeys.Contains(key))
            {
                return Direction.DOWN;
            }

            if (_RightKeys.Contains(key))
            {
                return Direction.RIGHT;
            }

            if (_LeftKeys.Contains(key))
            {
                return Direction.LEFT;
            }

            return Direction.UP;
        }

        private static KeyCode IsUpBeingPressed()
        {
            return IsKeyBeingPressedFromDirection(_UpKeys);
        }

        private static KeyCode IsLeftBeingPressed()
        {
            return IsKeyBeingPressedFromDirection(_LeftKeys);
        }

        private static KeyCode IsRightBeingPressed()
        {
            return IsKeyBeingPressedFromDirection(_RightKeys);
        }

        private static KeyCode IsDownBeingPressed()
        {
            return IsKeyBeingPressedFromDirection(_DownKeys);
        }

        private static KeyCode IsKeyBeingPressedFromDirection(List<KeyCode> keys)
        {
            foreach (KeyCode key in keys)
            {
                if (Input.GetKeyDown(key))
                {
                    return key;
                }
            }

            return KeyCode.None;
        }

        private static float OnKeysPressed(ControlScheme placement, bool isHorizontal)
        {
            string axisName = string.Empty;
            switch (placement)
            {
                case ControlScheme.WASD:
                    axisName = _WASD;
                    break;
                case ControlScheme.YGHJ:
                    axisName = _YGHJ;
                    break;
                case ControlScheme.PL:
                    axisName = _PL;
                    break;
                case ControlScheme.KEYS:
                    axisName = _KEY;
                    break;
            }

            string axis = isHorizontal ? _Horizontal : _Vertical;
            return (axisName.Length == 0) ? 0 : Input.GetAxis(axisName + axis);
        }
    }
}
