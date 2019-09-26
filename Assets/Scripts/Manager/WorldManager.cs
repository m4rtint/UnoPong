using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPHT;

[RequireComponent(typeof(PlayerMaterials))]
public class WorldManager : MonoBehaviour
{
    // Placeholder
    private static int _numberOfPlayers = 2;


    [Header("Managers")]
    [SerializeField]
    private BoardManager _boardManager;
    [SerializeField]
    private PlayerManager _playerManager;

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

    public static event Action OnFixedUpdate;


    private void Start()
    {
        _boardManager.Initialize(BoardTemplates.BoardThree, _numberOfPlayers, _playerMaterial);
    }

    private void FixedUpdate()
    {
        if (OnFixedUpdate != null)
        {
            OnFixedUpdate();
        }
    }
}
