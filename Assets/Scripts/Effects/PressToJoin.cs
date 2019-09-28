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
    using UnityEngine.UI;
    using TMPro;

    /// <summary>
    /// Animation effects for keys press to enter
    /// </summary>
    public class PressToJoin : MonoBehaviour
    {
        [SerializeField]
        private Image _keyIcon;
        [SerializeField]
        TextMeshProUGUI[] _pressToStart;
        [SerializeField]
        private Direction _direction;

        /// <summary>
        /// Gets direction of this start button
        /// </summary>
        public Direction Direction => _direction;

        public void SetSideAsDisabled()
        {
            foreach(TextMeshProUGUI text in _pressToStart)
            {
                text.color = Color.grey;
            }

            _keyIcon.color = Color.grey;
        }

        public void SetSideAsEnabled()
        {

        }

        private void Awake()
        {
            _keyIcon.gameObject.LeanScale(Vector3.one * 0.8f, 1f).setLoopPingPong(int.MaxValue);
        }
    }
}