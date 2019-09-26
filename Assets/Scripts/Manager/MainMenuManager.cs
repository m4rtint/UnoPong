//-----------------------------------------------------------------------
// <copyright file="MainMenuManager.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Infinite State Machine for main menu state
    /// </summary>
    public enum MenuState
    {
        /// <summary>
        /// Player selects direction for player one
        /// </summary>
        PlayerSelection_PlayerOne,

        /// <summary>
        /// Player selects direction for player two
        /// </summary>
        PlayerSelection_PlayerTwo,

        /// <summary>
        /// Player selects direction for player three
        /// </summary>
        PlayerSelection_PlayerThree,

        /// <summary>
        /// Select the board
        /// </summary>
        BoardSelection,

        /// <summary>
        /// In Game
        /// </summary>
        InGame
    }

    /// <summary>
    /// Handles Main Menu, only works in PreGame State
    /// </summary>
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField]
        private PressToJoin[] _pressToJoinSides;
        private MenuState _state = MenuState.PlayerSelection_PlayerOne;
        private Player _currentPlayer = Player.PLAYER_ONE;
        private Direction _firstChosenDirection;

        private MainMenuManagerBehaviour _behaviour = new MainMenuManagerBehaviour();

        private PressToJoin[] PressToJoinSides
        {
            get
            {
                if (_pressToJoinSides == null)
                {
                    _pressToJoinSides = GetComponentsInChildren<PressToJoin>();
                }

                return _pressToJoinSides;
            }
        }
        /// <summary>
        /// Called when player selected initial position of platform
        /// </summary>
        public event Action<Player, Direction, ControlScheme> OnPlayerSelected;

        private void Update()
        {
            switch (_state)
            {
                case MenuState.PlayerSelection_PlayerOne:
                    OnPlayerSelection();
                    break;
                case MenuState.BoardSelection:
                    break;
                case MenuState.InGame:
                    break;
            }
        }

        private void OnPlayerSelection()
        {
            SelectSchemeToPlayer(_currentPlayer);
        }

        private void SelectSchemeToPlayer(Player player)
        {
            // Get Which KeyCode is pressed
            KeyCode key = InputManager.IsAnyKeyBeingPressed();

            if (key != KeyCode.None)
            {
                //use Key to find direction
                Direction chosenDirection = InputManager.GetDirectionFromKeyCode(key);
                //use key to find control scheme
                ControlScheme controls = InputManager.GetSchemeFromKeyCode(key);

                RemoveStartFromDirection(chosenDirection);
                //OnPlayerSelected(player, chosenDirection, controls);
                _currentPlayer++;
            }
        }

        private void RemoveStartFromDirection(Direction direction)
        {
            foreach (PressToJoin join in PressToJoinSides)
            {
                if (join.Direction == direction)
                {
                    join.gameObject.SetActive(false);
                }
            }
        }
    }
}
