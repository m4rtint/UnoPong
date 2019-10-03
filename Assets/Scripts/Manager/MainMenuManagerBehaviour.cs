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
        private IInputManager _inputManager;
        private List<Direction> _listOfOpenDirections = new List<Direction>() { Direction.UP, Direction.DOWN, Direction.LEFT, Direction.RIGHT };
        private HashSet<ControlScheme> _setOfTakenControlSchemes = new HashSet<ControlScheme>();
        private Direction _firstChosenDirection;

        // Data to pass back
        private Player _playersJoined = Player.PLAYER_ONE;
        private int _currentBoardSelection = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuManagerBehaviour" /> class.
        /// </summary>
        /// <param name="inputManager">Input Manager</param>
        public MainMenuManagerBehaviour(IInputManager inputManager)
        {
            _inputManager = inputManager;
        }

        /// <summary>
        /// On Platform selected, pass data back
        /// </summary>
        public event Action<Player, Direction, ControlScheme> OnPlatformSelected;

        /// <summary>
        /// Gets or sets of taken control schemes
        /// </summary>
        public HashSet<ControlScheme> SetOfTakenControlSchemes
        {
            get
            {
                return _setOfTakenControlSchemes;
            }

            set
            {
                _setOfTakenControlSchemes = value;
            }
        }

        /// <summary>
        /// The Current Player choosing the platform
        /// </summary>
        public Player CurrentAmountOfPlayersJoin => _playersJoined;

        /// <summary>
        /// Current Board Selection
        /// </summary>
        public int CurrentBoardSelection { get => _currentBoardSelection; set => _currentBoardSelection = value; }

        public Direction FirstChosenDirection
        {
            get
            {
                return _firstChosenDirection;
            }

            set
            {
                _firstChosenDirection = value;
            }
        }

        /// <summary>
        /// Gets or sets List of available directions
        /// </summary>
        public List<Direction> ListOfOpenDirections
        {
            get
            {
                return _listOfOpenDirections;
            }

            set
            {
                _listOfOpenDirections = value;
            }
        }

        /// <summary>
        /// Gets Input Manager for dependency injection
        /// </summary>
        public IInputManager InputManager
        {
            get
            {
                if (_inputManager == null)
                {
                    _inputManager = MPHT.InputManager.Instance;
                }

                return _inputManager;
            }
        }

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
            ListOfOpenDirections.Remove(direction);
            SetOfTakenControlSchemes.Add(controlScheme);

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
            KeyCode key = _inputManager.IsAnyKeyBeingPressed();
            if (key != KeyCode.None)
            {
                Direction chosenDirection = _inputManager.GetDirectionFromKeyCode(key);
                ControlScheme controls = _inputManager.GetSchemeFromKeyCode(key);
                OnPlatformSelected?.Invoke(_playersJoined, chosenDirection, controls);
            }
        }
        
        /// <summary>
        /// Checks if one direction is being pressed based on cached information on this object
        /// Pass data back through delegate
        /// </summary>
        public void PlayerTwoSelection()
        {
            if (SetOfTakenControlSchemes.Count != 1)
            {
                throw new Exception("This is supposed to only have 1 elements. If not there will be problems");
            }

            Direction chosenDirection = OppositeDirection(_firstChosenDirection);
            KeyCode key = _inputManager.IsKeyBeingPressedAt(chosenDirection);
            if (key != KeyCode.None)
            {
                ControlScheme controls = _inputManager.GetSchemeFromKeyCode(key);
                if (!SetOfTakenControlSchemes.Contains(controls))
                {
                    OnPlatformSelected?.Invoke(_playersJoined, chosenDirection, controls);
                    _playersJoined++;
                }
            }
        }

        /// <summary>
        /// Checks two directions to see if either player is entering
        /// Pass data back through delegate
        /// </summary>
        public void PlayerThreeSelection()
        {
            if (SetOfTakenControlSchemes.Count != 2)
            {
                throw new Exception("This is supposed to only have 2 elements. If not there will be problems");
            }

            bool isHorizontalAvailable = ListOfOpenDirections.Contains(Direction.LEFT);
            KeyCode key = _inputManager.IsKeyBeingPressOnAxis(isHorizontalAvailable);
        
            if (key != KeyCode.None)
            {
                Direction chosenDirection = _inputManager.GetDirectionFromKeyCode(key);
                ControlScheme controls = _inputManager.GetSchemeFromKeyCode(key);
                if (!SetOfTakenControlSchemes.Contains(controls))
                {
                    OnPlatformSelected?.Invoke(_playersJoined, chosenDirection, controls);
                    _playersJoined++;
                }
            }
        }

        /// <summary>
        /// Checks and allows fourth player to enter the game
        /// </summary>
        public void PlayerFourSelection()
        {
            if (SetOfTakenControlSchemes.Count != 3)
            {
                throw new Exception("At this stage, there is supposed to be only ONE left.");
            }

            Direction chosenDirection = ListOfOpenDirections[0];
            KeyCode key = _inputManager.IsKeyBeingPressedAt(chosenDirection);
            if (key != KeyCode.None)
            {
                ControlScheme controls = _inputManager.GetSchemeFromKeyCode(key);
                if (!SetOfTakenControlSchemes.Contains(controls))
                {
                    OnPlatformSelected?.Invoke(_playersJoined, chosenDirection, controls);
                    _playersJoined++;
                }
            }
        }

        /// <summary>
        /// Returns board to render in board selection
        /// </summary>
        /// <param name="left">is cycling to left</param>
        /// <returns>board to render</returns>
        public bool[] CycleThroughBoards(bool left)
        {
            LeanTween.cancelAll();
            _currentBoardSelection += left ? -1 : 1;
            if (_currentBoardSelection >= BoardTemplates.Boards.Length)
            {
                _currentBoardSelection = 0;
            } else if (_currentBoardSelection < 0 )
            {
                _currentBoardSelection = BoardTemplates.Boards.Length - 1;
            }

            return BoardTemplates.Boards[_currentBoardSelection];
        }
    }
}
