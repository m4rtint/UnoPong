//-----------------------------------------------------------------------
// <copyright file="PlatformControlsBehaviour.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Platform control logic
    /// </summary>
    public class PlatformControlsBehaviour
    {
        private const float _ClampedPosition = 3.0f;
        private const float _VerticalAngle = 90f;
        private const float _BentPlatformRotation = 20f;

        /// <summary>
        /// Gets the amount the player can move
        /// </summary>
        /// <param name="playerPlat">Player Platform</param>
        /// <param name="amount">speed amount</param>
        /// <returns>move amount</returns>
        public Vector3 PlayerMovement(PlayerPlatform playerPlat, float amount)
        {
            float input = 0;
            
            if (IsVerticalMovement(playerPlat))
            {
                input = InputManager.Instance.OnVerticalPressed(playerPlat.Input);
            }
            else
            {
                input = InputManager.Instance.OnHorizontalPressed(playerPlat.Input);
            }
            
            float direction = 0;
            if (input > 0)
            {
                direction = 1;
            }
            else if (input < 0)
            {
                direction = -1;
            }

            Vector3 movementDirection = Vector3.zero;
            if (IsVerticalMovement(playerPlat))
            {
                movementDirection = new Vector3(0, amount * direction);
            }
            else
            {
                movementDirection = new Vector3(amount * direction, 0);
            }

            return movementDirection;
        }

        /// <summary>
        /// On Press vertical or horizontal buttons, platform rotates by 20 degrees
        /// </summary>
        /// <param name="playerPlat">platform to rotate</param>
        /// <returns>Quaternion angle</returns>
        public Quaternion PlayerRotation(PlayerPlatform playerPlat)
        {
            float input = 0;
            bool isVertical = IsVerticalMovement(playerPlat);
            if (!isVertical)
            {
                input = InputManager.Instance.OnVerticalPressed(playerPlat.Input);
            }
            else
            {
                input = InputManager.Instance.OnHorizontalPressed(playerPlat.Input);
            }

            float angle = isVertical ? _VerticalAngle : 0;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            if (input > 0)
            {
                rotation = Quaternion.Euler(0, 0, angle + _BentPlatformRotation);
            }
            else if (input < 0)
            {
                rotation = Quaternion.Euler(0, 0, angle - _BentPlatformRotation);
            }

            return rotation;
        }

        /// <summary>
        /// Clamps position of platform between the given values
        /// </summary>
        /// <param name="playerPlat">Current player platform</param>
        /// <param name="position">current position of platform</param>
        /// <returns>position to be</returns>
        public Vector3 ClampedPosition(PlayerPlatform playerPlat, Vector3 position)
        {
            if (IsVerticalMovement(playerPlat))
            {
                return new Vector3(position.x, Mathf.Clamp(position.y, -_ClampedPosition, _ClampedPosition));
            }
            else
            {
                return new Vector3(Mathf.Clamp(position.x, -_ClampedPosition, _ClampedPosition), position.y);
            }
        }

        private bool IsVerticalMovement(PlayerPlatform player)
        {
            return player.Direction == Direction.LEFT || player.Direction == Direction.RIGHT;
        }
    }
}