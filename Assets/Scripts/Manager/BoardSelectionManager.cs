//-----------------------------------------------------------------------
// <copyright file="BoardSelectionManager.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Selecting the board manager
/// </summary>
public class BoardSelectionManager : MonoBehaviour
{
    [SerializeField]
    private Button _left;
    [SerializeField]
    private Button _right;

    /// <summary>
    /// On Clicking change board where true is right, false to the left
    /// </summary>
    public event Action<bool> OnChangeBoardClick;

    private void Awake()
    {
        _left.onClick.AddListener(delegate { OnChangeBoardClick?.Invoke(false); });
        _right.onClick.AddListener(delegate { OnChangeBoardClick?.Invoke(true); });
    }
}
