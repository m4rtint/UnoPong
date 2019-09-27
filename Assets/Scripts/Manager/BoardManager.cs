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
        private BoardManagerBehaviour _boardBehaivour;

        private GameObject[] _boardOfBricks = new GameObject[_AmountOfBricks];

        public void Initialize()
        {
            _boardBehaivour = new BoardManagerBehaviour();
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
            _boardBehaivour.CheckTemplate(boardTemplate, _boardOfBricks);
            SetupBoard(players, playerMaterials, boardTemplate);
        }

        public void RenderOutline(bool[] boardTemplate, PlayerMaterials playerMaterials)
        {
            _boardBehaivour.CheckTemplate(boardTemplate, _boardOfBricks);
            bool[] outlined = _boardBehaivour.BoardOutlinedBricks(boardTemplate, _WidthAndHeightOfGrid);
            for (int i = 0; i < _AmountOfBricks; i++)
            {
                _boardOfBricks[i].transform.position = MPHT.Utilities.IndexToVector(i, _WidthAndHeightOfGrid);
                _boardOfBricks[i].GetComponent<SpriteRenderer>().material = playerMaterials.GetDefaultMaterial();
                _boardOfBricks[i].SetActive(outlined[i]);
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
                _boardOfBricks[i].transform.position = MPHT.Utilities.IndexToVector(i, _WidthAndHeightOfGrid);
                _boardOfBricks[i].GetComponent<SpriteRenderer>().material = GetRandomMaterial(players, playerMaterials);
                _boardOfBricks[i].SetActive(boardTemplate[i]);
            }
        }

        private Material GetRandomMaterial(int players, PlayerMaterials mat)
        {
            return mat.GetPlayerMaterialFor(MPHT.Utilities.RandomPlayer(players));
        }
    }
}
