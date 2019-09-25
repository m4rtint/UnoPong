using UnityEngine;

namespace MPHT {
    public class BoardManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _brick;

        private const int _widthAndHeightOfGrid = 13;
        private const int _AmountOfBricks = _widthAndHeightOfGrid * _widthAndHeightOfGrid;

        GameObject[] _boardOfBricks = new GameObject[_AmountOfBricks];

        public void Initialize(bool[] boardTemplate, int players, PlayerMaterials playerMaterials)
        {
            CheckTemplate(boardTemplate);
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
                _boardOfBricks[i].transform.position = MPHT.Utilities.IndexToVector(i, _widthAndHeightOfGrid);
                _boardOfBricks[i].GetComponent<SpriteRenderer>().material = GetRandomMaterial(players, playerMaterials);
                _boardOfBricks[i].SetActive(boardTemplate[i]);
            }
        }

        private Material GetRandomMaterial(int players, PlayerMaterials mat)
        {
            int index = Random.Range(0, players);
            switch (index)
            {
                case 0:
                    return mat.PlayerOneMaterial;
                case 1:
                    return mat.PlayerTwoMaterial;
                case 2:
                    return mat.PlayerThreeMaterial;
                case 3:
                    return mat.PlayerFourMaterial;
                default:
                    return mat.PlayerOneMaterial;
            }
        }

        private void CheckTemplate(bool[] boardTemplate)
        {
            if (boardTemplate.Length != _boardOfBricks.Length)
            {
                throw new System.Exception($"Board template amount not exact: board has {_boardOfBricks.Length} bricks, template has {boardTemplate.Length} bricks");
            }
        }

    }
}