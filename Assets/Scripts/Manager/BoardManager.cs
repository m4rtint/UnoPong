using UnityEngine;
using UnityEngine.Assertions;

namespace MPHT {
    public class BoardManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _brick;

        private const int _WidthAndHeightOfGrid = 13;
        private const int _AmountOfBricks = _WidthAndHeightOfGrid * _WidthAndHeightOfGrid;

        GameObject[] _boardOfBricks = new GameObject[_AmountOfBricks];

        public void Initialize(bool[] boardTemplate, int players, PlayerMaterials playerMaterials)
        {
            BoardManagerBehaivours boardBehaivour = new BoardManagerBehaivours();
            boardBehaivour.CheckTemplate(boardTemplate, _boardOfBricks);
            InstantiateBoard();
            SetupBoard(players, playerMaterials, boardTemplate);
        }

        private void InstantiateBoard()
        {
            for (int i = 0; i < _AmountOfBricks; i++)
            {
                GameObject obj = (GameObject)Instantiate(_brick);
                obj.transform.parent = transform;
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

    public class BoardManagerBehaivours
    {
        public void CheckTemplate(bool[] boardTemplate, GameObject[] board)
        {
            if (boardTemplate.Length != board.Length)
            {
                throw new System.Exception($"Board template amount not exact: board has {board.Length} bricks, template has {boardTemplate.Length} bricks");
            }
        }
    }
}