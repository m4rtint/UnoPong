using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPHT;

public interface IMaterials
{
    Material GetPlayerMaterialFor(Player player);
}

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
