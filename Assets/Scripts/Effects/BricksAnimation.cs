//-----------------------------------------------------------------------
// <copyright file="BricksAnimation.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Animation for the rotation of the whole center bricks
/// </summary>
public class BricksAnimation : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            float scale = Time.timeScale;
            Time.timeScale = 0;
            float z = transform.eulerAngles.z + 90;
            transform.LeanRotateZ(z, 2f)
                .setOnComplete(() => { Time.timeScale = scale; })
                .setIgnoreTimeScale(true);
        }
    }
}
