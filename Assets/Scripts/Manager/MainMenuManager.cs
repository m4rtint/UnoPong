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
    using UnityEngine.UI;

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
        /// Player selects direction for player four
        /// </summary>
        PlayerSelection_PlayerFour,

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
        [Header("Buttons")]
        [SerializeField]
        private Button _nextButton;
        [SerializeField]
        private Button _startButton;
        [SerializeField]
        private BoardSelectionManager _boardSelection;
        private MenuState _state = MenuState.PlayerSelection_PlayerOne;

        private MainMenuManagerBehaviour _behaviour = new MainMenuManagerBehaviour(InputManager.Instance);

        /// <summary>
        /// Called when player selected initial position of platform
        /// </summary>
        public event Action<Player, Direction, ControlScheme> OnPlayerSelected;

        /// <summary>
        /// Render board outline
        /// </summary>
        public event Action<bool[]> OnBoardRender;

        /// <summary>
        /// Logic for when game starts
        /// </summary>
        public event Action<bool[], Player> OnGameStart;

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

        private void Awake()
        {
            _behaviour.OnPlatformSelected += OnPlatformSelected;
            _boardSelection.OnChangeBoardClick += OnChangeBoard;
            SetupNextButton();
            SetupStartButton();
        }

        private void Update()
        {
            switch (_state)
            {
                case MenuState.PlayerSelection_PlayerOne:
                    _behaviour.PlayerOneSelection();
                    break;
                case MenuState.PlayerSelection_PlayerTwo:
                    _behaviour.PlayerTwoSelection();
                    break;
                case MenuState.PlayerSelection_PlayerThree:
                    _behaviour.PlayerThreeSelection();
                    _nextButton.interactable = true;
                    break;
                case MenuState.PlayerSelection_PlayerFour:
                    _behaviour.PlayerFourSelection();
                    break;
                case MenuState.BoardSelection:
                    break;
                case MenuState.InGame:
                    break;
            }
        }

        private void OnChangeBoard(bool left)
        {
            OnBoardRender(_behaviour.CycleThroughBoards(left));
        }

        private void SetupNextButton()
        {
            _nextButton.interactable = false;
            _nextButton.onClick.AddListener(() =>
            {
                if ((int)_state <= 3)
                {
                    ActivateBoardSelection();
                }
            });
        }

        private void ActivateBoardSelection()
        {
            _state = MenuState.BoardSelection;
            RemoveAllPressToJoin();
            _nextButton.gameObject.SetActive(false);
            SetBoardSelectionActiveStates(true);
            OnBoardRender(BoardTemplates.BoardOne);
        }

        private void SetupStartButton()
        {
            _startButton.gameObject.SetActive(false);
            _startButton.onClick.AddListener(() =>
            {
                _startButton.gameObject.SetActive(false);
                OnGameStart(BoardTemplates.Boards[_behaviour.CurrentBoardSelection], _behaviour.CurrentPlayer); 
            });
        }

        private void SetBoardSelectionActiveStates(bool state)
        {
            _startButton.gameObject.SetActive(true);
            _boardSelection.gameObject.SetActive(true);
        }

        private void RemoveAllPressToJoin()
        {
            foreach (PressToJoin join in PressToJoinSides)
            {
                join.gameObject.SetActive(false);
            }
        }

        private void RemoveStartFromDirection(Direction direction, ControlScheme scheme)
        {
            HashSet<Direction> listOfObjectsToDeactivate = _behaviour.DirectionToDeactivate(direction, scheme);
            foreach (PressToJoin join in PressToJoinSides)
            {
                bool activate = !listOfObjectsToDeactivate.Contains(join.Direction);
                join.gameObject.SetActive(activate);
            }
        }
        
        private void OnPlatformSelected(Player playerNumber, Direction direction, ControlScheme scheme)
        {
            _state++;
            if (_state == MenuState.BoardSelection)
            {
                ActivateBoardSelection();
            }

            RemoveStartFromDirection(direction, scheme);
            OnPlayerSelected(playerNumber, direction, scheme);
        }
    }
}
