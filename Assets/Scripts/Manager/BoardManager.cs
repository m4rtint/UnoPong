using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _brick;

    private const int m_widthAndHeightOfGrid = 13;
    private const int m_AmountOfBricks = m_widthAndHeightOfGrid * m_widthAndHeightOfGrid;

    GameObject[] boardOfBricks = new GameObject[m_AmountOfBricks];

    public void Initialize(bool[] boardTemplate, int players, PlayerMaterials playerMaterials)
    {
        CheckTemplate(boardTemplate);
        for (int i = 0; i < m_AmountOfBricks; i++)
        {
            GameObject obj = (GameObject)Instantiate(_brick);
            obj.transform.parent = transform;
            boardOfBricks[i] = obj;
        }

        int index = 0;
        for (double y = 3; y >= -3; y -= 0.5)
        {
            for (double x = -3; x <= 3; x += 0.5)
            {
                if (boardTemplate[index])
                {
                    boardOfBricks[index].transform.position = new Vector3((float)x, (float)y);
                    boardOfBricks[index].GetComponent<SpriteRenderer>().material = GetRandomMaterial(players, playerMaterials);
                }
                boardOfBricks[index].SetActive(boardTemplate[index]);
                
                index++;
            }
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
        if (boardTemplate.Length != boardOfBricks.Length)
        {
            throw new System.Exception($"Board template amount not exact: board has {boardOfBricks.Length} bricks, template has {boardTemplate.Length} bricks");
        }
    }
    
}
