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
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Animation effects for keys press to enter
    /// </summary>
    public class PressToJoin : MonoBehaviour
    {
        [SerializeField]
        private Image _keyIcon;
        [SerializeField]
        private TextMeshProUGUI[] _pressToStart;
        [SerializeField]
        private Direction _direction;

        /// <summary>
        /// Gets direction of this start button
        /// </summary>
        public Direction Direction => _direction;

        /// <summary>
        /// Gets Keyboard key icons
        /// </summary>
        public Image KeyIcon
        {
            get
            {
                if (_keyIcon == null)
                {
                    _keyIcon = GetComponentInChildren<Image>();
                }

                return _keyIcon;
            }
        }

        /// <summary>
        /// Sets the press to join side as disabled
        /// </summary>
        public void SetSideAsDisabled()
        {
            foreach (TextMeshProUGUI text in _pressToStart)
            {
                text.color = Color.grey;
            }

            _keyIcon.color = Color.grey;
        }

        /// <summary>
        /// Sets the press to join appearance as enabled
        /// </summary>
        public void SetSideAsEnabled()
        { 
        }

        private void Awake()
        {
            KeyIcon.gameObject.LeanScale(Vector3.one * 0.8f, 1f).setLoopPingPong(int.MaxValue);
        }
    }
}