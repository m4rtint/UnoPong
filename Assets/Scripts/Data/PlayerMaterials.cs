//-----------------------------------------------------------------------
// <copyright file="PlayerMaterials.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using MPHT;
using UnityEngine;

/// <summary>
/// Storage for Players Material - changes its color depending on the material
/// </summary>
public class PlayerMaterials : MonoBehaviour, IMaterials
{
    [SerializeField]
    private Material _playerOneMaterial;
    [SerializeField]
    private Material _playerTwoMaterial;
    [SerializeField]
    private Material _playerThreeMaterial;
    [SerializeField]
    private Material _playerFourMaterial;
    [SerializeField]
    private Material _defaultMaterial;

    /// <summary>
    /// Gets the material dedicated for specific player
    /// </summary>
    /// <param name="player">Player Number</param>
    /// <returns>Material for player</returns>
    public Material GetPlayerMaterialFor(Player player)
    {
        switch (player)
        {
            case Player.PLAYER_ONE:
                return _playerOneMaterial;
            case Player.PLAYER_TWO:
                return _playerTwoMaterial;
            case Player.PLAYER_THREE:
                return _playerThreeMaterial;
            case Player.PLAYER_FOUR:
                return _playerFourMaterial;
            default:
                return _defaultMaterial;
        }
    }
}
