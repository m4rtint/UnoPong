//-----------------------------------------------------------------------
// <copyright file="BoardManager.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using UnityEngine;
    using UnityEngine.Assertions;

    /// <summary>
    /// Manages the boards data
    /// </summary>
    public class BoardManager : MonoBehaviour
    {
        private const int _WidthAndHeightOfGrid = 13;
        private const int _AmountOfBricks = _WidthAndHeightOfGrid * _WidthAndHeightOfGrid;

        [SerializeField]
        private GameObject _brick;
        private BoardManagerBehaviour _boardBehaviour;

        private GameObject[] _boardOfBricks = new GameObject[_AmountOfBricks];

        /// <summary>
        /// Initializes the Board manager
        /// </summary>
        public void Initialize()
        {
            _boardBehaviour = new BoardManagerBehaviour();
            InstantiateBoard();
        }

        /// <summary>
        /// Initializes the board according to template and players
        /// </summary>
        /// <param name="boardTemplate">template for the board</param>
        /// <param name="players">amount of players in game</param>
        /// <param name="playerMaterials">materials for player</param>
        public void InitializeChosenBoard(bool[] boardTemplate, int players, PlayerMaterials playerMaterials)
        {
            _boardBehaviour.CheckTemplate(boardTemplate, _boardOfBricks);
            SetupBoard(players, playerMaterials, boardTemplate);
        }

        /// <summary>
        /// Renders the outline of the board
        /// </summary>
        /// <param name="boardTemplate">template of the board to render</param>
        /// <param name="playerMaterials">material loader</param>
        public void RenderOutline(bool[] boardTemplate, PlayerMaterials playerMaterials)
        {
            TurnOffAllBricks();
            _boardBehaviour.CheckTemplate(boardTemplate, _boardOfBricks);
            bool[] outlined = _boardBehaviour.OutlinedBricks(boardTemplate, _WidthAndHeightOfGrid);
            for (int i = 0; i < _AmountOfBricks; i++)
            {
                ActivateBrick(i, playerMaterials.GetDefaultMaterial(), outlined[i]);
            }
        }

        private void TurnOffAllBricks()
        {
            foreach(GameObject brick in _boardOfBricks)
            {
                brick.SetActive(false);
            }
        }

        private void InstantiateBoard()
        {
            for (int i = 0; i < _AmountOfBricks; i++)
            {
                GameObject obj = (GameObject)Instantiate(_brick);
                obj.transform.parent = transform;
                obj.SetActive(false);
                _boardOfBricks[i] = obj;
            }
        }

        private void SetupBoard(int players, PlayerMaterials playerMaterials, bool[] boardTemplate)
        {
            for (int i = 0; i < _AmountOfBricks; i++)
            {
                ActivateBrick(i, GetRandomMaterial(players, playerMaterials), boardTemplate[i]);
            }
        }

        private void ActivateBrick(int index, Material mat, bool isActive)
        {
            GameObject brick = _boardOfBricks[index];
            brick.transform.position = _boardBehaviour.IndexToVector(index, _WidthAndHeightOfGrid);
            brick.GetComponent<SpriteRenderer>().material = mat;
            brick.SetActive(isActive);
            AnimateBrick(index);
        }

        private void AnimateBrick(int index)
        {
            _boardOfBricks[index].transform.localScale = Vector3.zero;
            _boardOfBricks[index].LeanScale(Vector3.one, 0.1f)
                .setDelay(0.1f * Mathf.Floor(index/_WidthAndHeightOfGrid))
                .setEaseOutCirc();
            
        }

        private Material GetRandomMaterial(int players, PlayerMaterials mat)
        {
            return mat.GetPlayerMaterialFor(MPHT.Utilities.RandomPlayer(players));
        }
    }
}
