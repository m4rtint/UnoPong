using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPHT;

[RequireComponent(typeof(PlayerMaterials))]
public class WorldManager : MonoBehaviour
{
    public static event Action OnFixedUpdate;

    //PlaceHolder
    private static int _numberOfPlayers = 2;

    private PlayerMaterials _playerMaterial;

    [Header("Managers")]
    [SerializeField]
    private BoardManager _boardManager;
    [SerializeField]
    private PlayerManager _playerManager;

    private void Awake()
    {
        _playerMaterial = GetComponent<PlayerMaterials>();
    }

    private void Start()
    {

        _boardManager.Initialize(BoardTemplates.board_Three, 4, _playerMaterial);
    }

    private void FixedUpdate()
    {
        if (OnFixedUpdate != null)
        {
            OnFixedUpdate();
        }
    }
}
