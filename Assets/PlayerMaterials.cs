using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterials : MonoBehaviour
{
    [SerializeField]
    private Material _playerOneMaterial;
    [SerializeField]
    private Material _playerTwoMaterial;
    [SerializeField]
    private Material _playerThreeMaterial;
    [SerializeField]
    private Material _playerFourMaterial;

    public Material PlayerOneMaterial
    {
        get
        {
            return _playerOneMaterial;
        }
    }

    public Material PlayerTwoMaterial
    {
        get
        {
            return _playerTwoMaterial;
        }
    }

    public Material PlayerThreeMaterial
    {
        get
        {
            return _playerThreeMaterial;
        }
    }

    public Material PlayerFourMaterial
    {
        get
        {
            return _playerFourMaterial;
        }
    }

}
