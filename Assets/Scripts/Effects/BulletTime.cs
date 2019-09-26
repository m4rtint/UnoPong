//-----------------------------------------------------------------------
// <copyright file="BulletTime.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Slows down time depending on collision triggers
    /// </summary>
    public class BulletTime : MonoBehaviour
    {
        private float scale = 100f;
        private float bulletTimeScale = 0.1f;

        private void Start()
        {
            Time.timeScale = scale;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Time.timeScale = bulletTimeScale;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Time.timeScale = scale;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
            }
        }
    }
}
