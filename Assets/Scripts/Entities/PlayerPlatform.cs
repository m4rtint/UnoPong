//-----------------------------------------------------------------------
// <copyright file="PlayerPlatform.cs" company="Martin Pak Hei Tsang">
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
    /// Player platform properties
    /// </summary>
    [RequireComponent(typeof(TrailRenderer))]
    [RequireComponent(typeof(PlatformControls))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerPlatform : MonoBehaviour, IPlatform
    {
        private Direction _direction;
        private Player _player;
        private SpriteRenderer _spriteRenderer;
        private ControlScheme _inputPlacement;

        /// <summary>
        /// Direction of where player currently is
        /// </summary>
        public Direction Direction => _direction;

        /// <summary>
        /// Player Number
        /// </summary>
        public Player Player => _player;

        /// <summary>
        /// Where on keyboard is the input 
        /// </summary>
        public ControlScheme Input => _inputPlacement;

        /// <summary>
        /// Initialized the platform
        /// </summary>
        /// <param name="position">position of where the platform will be</param>
        /// <param name="rotation">rotation of platform</param>
        /// <param name="direction">which side will platform be at</param>
        /// <param name="player">which player number</param>
        /// <param name="mat">material of player</param>
        /// <param name="placement">which keys allow input</param>
        public void Initialize(Vector3 position, Quaternion rotation, Direction direction, Player player, Material mat, ControlScheme placement)
        {
            _direction = direction;
            _player = player;
            _spriteRenderer.material = mat;
            _inputPlacement = placement;
            GetComponent<TrailRenderer>().material = mat;
            transform.position = position;
            transform.rotation = rotation;
            AnimateOpeningOfPlatform();
        }

        /// <summary>
        /// Set GameObject as inactive
        /// </summary>
        public void TurnOffPlatform()
        {
            gameObject.SetActive(false);
        }

        private void AnimateOpeningOfPlatform()
        {
            Effect fx = FXObjectPooler.Instance.GetMediumExplosionFromPlayer(_player);
            FXObjectPooler.Instance.SpawnFromPool(fx, transform.position, Quaternion.identity);
            gameObject.SetActive(true);
            SetControlsEnabled(false);
            transform.localScale = new Vector3(0, 1);
            transform.LeanScaleX(1, 1)
                .setEaseOutBack()
                .setOnComplete(() => { SetControlsEnabled(true); })
                .setDelay(0.5f);
        }

        private void SetControlsEnabled(bool enable)
        {
            GetComponent<PlatformControls>().AllowMovement = enable;
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }
}
