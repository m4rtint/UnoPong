//-----------------------------------------------------------------------
// <copyright file="MainMenuManagerBehaviour.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System;
    using System.Collections.Generic;
    using MPHT;
    using UnityEngine;

    /// <summary>
    /// Logic for the main menu
    /// </summary>
    public class MainMenuManagerBehaviour
    {
        private List<Direction> _listOfOpenDirections = new List<Direction>() { Direction.UP, Direction.DOWN, Direction.LEFT, Direction.RIGHT } ;
        private HashSet<ControlScheme> _setOfTakenControlSchemes = new HashSet<ControlScheme>();
        private Direction _firstChosenDirection;
        private Player _currentPlayer = Player.PLAYER_ONE;

        /// <summary>
        /// On Platform selected, pass data back
        /// </summary>
        public event Action<Player, Direction, ControlScheme> OnPlatformSelected;

        /// <summary>
        /// The first platform direction to be chosen
        /// </summary>
        public Direction FirstChosenDirection => _firstChosenDirection;

        /// <summary>
        /// Find the opposite direction of given direction
        /// </summary>
        /// <param name="dir">direction given</param>
        /// <returns>opposite direction</returns>
        public Direction OppositeDirection(Direction dir)
        {
            switch (dir)
            {
                case Direction.UP:
                    return Direction.DOWN;
                case Direction.LEFT:
                    return Direction.RIGHT;
                case Direction.RIGHT:
                    return Direction.LEFT;
                case Direction.DOWN:
                    return Direction.UP;
                default:
                    return Direction.UP;
            }
        }

        /// <summary>
        /// Which Direction start buttons to deactivate depending on state
        /// </summary>
        /// <param name="direction">Direction that was picked</param>
        /// <param name="controlScheme">Cache the control scheme</param>
        /// <returns>Set of Direction to deactivate</returns>
        public HashSet<Direction> DirectionToDeactivate(Direction direction, ControlScheme controlScheme)
        {
            HashSet<Direction> directions = new HashSet<Direction>() { Direction.UP, Direction.DOWN, Direction.LEFT, Direction.RIGHT };
            _listOfOpenDirections.Remove(direction);
            _setOfTakenControlSchemes.Add(controlScheme);

            if (_listOfOpenDirections.Count == 3)
            {
                directions.Remove(OppositeDirection(direction));
                _firstChosenDirection = direction;
            }
            else
            {
                directions.ExceptWith(_listOfOpenDirections);
            }

            return directions;
        }

        /// <summary>
        /// Checks all sides for player joining
        /// Pass data back through delegate
        /// </summary>
        public void PlayerOneSelection()
        {
            KeyCode key = InputManager.IsAnyKeyBeingPressed();
            if (key != KeyCode.None)
            {
                Direction chosenDirection = InputManager.GetDirectionFromKeyCode(key);
                ControlScheme controls = InputManager.GetSchemeFromKeyCode(key);

                OnPlatformSelected(_currentPlayer, chosenDirection, controls);
                _currentPlayer++;
            }
        }
        
        /// <summary>
        /// Checks if one direction is being pressed based on cached information on this object
        /// Pass data back through delegate
        /// </summary>
        public void PlayerTwoSelection()
        {
            Direction chosenDirection = OppositeDirection(FirstChosenDirection);
            KeyCode key = InputManager.IsKeyBeingPressedAt(chosenDirection);
            if (key != KeyCode.None)
            {
                ControlScheme controls = InputManager.GetSchemeFromKeyCode(key);
                if (!_setOfTakenControlSchemes.Contains(controls))
                {
                    OnPlatformSelected(_currentPlayer, chosenDirection, controls);
                    _currentPlayer++;
                }
            }
        }

        /// <summary>
        /// Checks two directions to see if either player is entering
        /// Pass data back through delegate
        /// </summary>
        public void PlayerThreeSelection()
        {
            if (_listOfOpenDirections.Count != 2)
            {
                throw new Exception("This is supposed to only have 2 elements. If not there will be problems");
            }

            KeyCode key = KeyCode.None;
            bool isHorizontalAvailable = _listOfOpenDirections.Contains(Direction.LEFT);
            key = InputManager.IsKeyBeingPressOnAxis(isHorizontalAvailable);
        
            if (key != KeyCode.None)
            {
                Direction chosenDirection = InputManager.GetDirectionFromKeyCode(key);
                ControlScheme controls = InputManager.GetSchemeFromKeyCode(key);
                if (!_setOfTakenControlSchemes.Contains(controls))
                {
                    OnPlatformSelected(_currentPlayer, chosenDirection, controls);
                    _currentPlayer++;
                }
            }
        }

        /// <summary>
        /// Checks the last side for the 4th player to enter
        /// </summary>
        public void PlayerFourSelection()
        {
            if (_listOfOpenDirections.Count != 1)
            {
                throw new Exception("At this stage, there is supposed to be only ONE left.");
            }

            Direction chosenDirection = _listOfOpenDirections[0];
            KeyCode key = InputManager.IsKeyBeingPressedAt(chosenDirection);
            if (key != KeyCode.None)
            {
                ControlScheme controls = InputManager.GetSchemeFromKeyCode(key);
                if (!_setOfTakenControlSchemes.Contains(controls))
                {
                    OnPlatformSelected(_currentPlayer, chosenDirection, controls);
                    _currentPlayer++;
                }
            }
        }
    }
}
