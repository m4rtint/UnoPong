//-----------------------------------------------------------------------
// <copyright file="OnCollision.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// On Object Collides
    /// </summary>
    public class OnCollision : MonoBehaviour
    {
        [SerializeField]
        private MPHT.Effect _effect;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == MPHT.Tags.Ball)
            {
                MPHT.FXObjectPooler.Instance.SpawnFromPool(_effect, transform.position, Quaternion.identity);
                MPHT.SimpleCameraShake.Instance.PlayShake();
                gameObject.SetActive(false);
            }
        }
    }
}
