﻿//-----------------------------------------------------------------------
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

        public Vector3 ClampedPosition(PlayerPlatform playerPlat, Vector3 position)
        {
            if (IsVerticalMovement(playerPlat))
            {
                return new Vector3(position.x, Mathf.Clamp(position.y, -3, 3));
            }
            else
            {
                return new Vector3(Mathf.Clamp(position.x, -3, 3), position.y);
            }
        }

        private bool IsVerticalMovement(PlayerPlatform player)
        {
            return player.Direction == Direction.LEFT || player.Direction == Direction.RIGHT;
        }
    }
}