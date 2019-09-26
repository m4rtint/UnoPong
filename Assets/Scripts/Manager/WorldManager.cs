using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPHT;

[RequireComponent(typeof(PlayerMaterials))]
public class WorldManager : MonoBehaviour
{
    //PlaceHolder
    private static int _numberOfPlayers = 2;

    private PlayerMaterials _playerMaterial;

    [SerializeField]
    private BoardManager _boardManager;

    private void Awake()
    {
        _playerMaterial = GetComponent<PlayerMaterials>();
    }

    private void Start()
    {

        _boardManager.Initialize(BoardTemplates.board_Three, 4, _playerMaterial);
    }
}
