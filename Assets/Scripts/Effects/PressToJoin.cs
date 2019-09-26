//-----------------------------------------------------------------------
// <copyright file="PressToJoin.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using MPHT;
    using UnityEngine;

    /// <summary>
    /// Animation effects for keys press to enter
    /// </summary>
    public class PressToJoin : MonoBehaviour
    {
        [SerializeField]
        private GameObject _keyIcon;
        [SerializeField]
        private Direction _direction;

        /// <summary>
        /// Gets direction of this start button
        /// </summary>
        public Direction Direction => _direction;

        private void Awake()
        {
            _keyIcon.LeanScale(Vector3.one * 0.8f, 1f).setLoopPingPong(int.MaxValue);
        }
    }
}