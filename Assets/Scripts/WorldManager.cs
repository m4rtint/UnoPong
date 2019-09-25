using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPHT;

[RequireComponent(typeof(PlayerMaterials))]
public class WorldManager : MonoBehaviour
{
    //PlaceHolder
    private static int _numberOfPlayers = 2;

    List<Player> _listOfPlayers = new List<Player>();
    PlayerManager _playerManager = new PlayerManager();
    private PlayerMaterials _playerMaterial;

    [SerializeField]
    private BoardManager _boardManager;

    private void Awake()
    {
        _playerMaterial = GetComponent<PlayerMaterials>();
    }

    private void Start()
    {
        for (int i = 0; i < _numberOfPlayers; i++)
        {
            _listOfPlayers.Add(_playerManager.CreatePlayer());
        }

        _boardManager.Initialize(BoardTemplates.board_Two, 4, _playerMaterial);
    }
}
