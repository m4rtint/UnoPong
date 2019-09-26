//-----------------------------------------------------------------------
// <copyright file="Ball.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Ball Properties
    /// </summary>
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private float _force = 10f;

        // Start is called before the first frame update
        private void Start()
        {
            var x = Random.Range(0, 1.0f);
            var y = Random.Range(0, 1.0f);
            PushBall(new Vector2(x, y));
        }

        private void PushBall(Vector2 direction)
        {
            GetComponent<Rigidbody2D>().AddForce(direction * _force);
        }
    }
}
