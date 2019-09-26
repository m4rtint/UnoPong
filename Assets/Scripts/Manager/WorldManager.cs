using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPHT;

[RequireComponent(typeof(PlayerMaterials))]
public class WorldManager : MonoBehaviour
{
    public static event Action OnFixedUpdate;
    
    // Placeholder
    private static int _numberOfPlayers = 2;

    private PlayerMaterials _playerMaterial;
    private PlayerMaterials PlayerMaterial
    {
        get
        {
            if (_playerMaterial == null)
            {
                _playerMaterial = GetComponent<PlayerMaterials>();
            }

            return _playerMaterial;
        }
    }

    [Header("Managers")]
    [SerializeField]
    private BoardManager _boardManager;
    [SerializeField]
    private PlayerManager _playerManager;
    
    private void Start()
    {

        _boardManager.Initialize(BoardTemplates.board_Three, _numberOfPlayers, _playerMaterial);
    }

    private void FixedUpdate()
    {
        if (OnFixedUpdate != null)
        {
            OnFixedUpdate();
        }
    }
}
