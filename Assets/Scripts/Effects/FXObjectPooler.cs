//-----------------------------------------------------------------------
// <copyright file="FXObjectPooler.cs" company="Martin Pak Hei Tsang">
//     Copyright (c) Martin Pak Hei Tsang. 2019 All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Particle Effect Enum
    /// </summary>
    public enum Effect
    {
        /// <summary>
        /// Blue Brick Break Particle Effect
        /// </summary>
        Blue_Brick_Break,

        Medium_Blue_Explosion,

        Red_Brick_Break,

        Medium_Red_Explosion,

        Yellow_Brick_Break,

        Medium_Yellow_Explosion,

        Green_Brick_Break,

        Medium_Green_Explosion,

        Default_Explosion
    }

    /// <summary>
    /// Object Pooler only for particle effects
    /// </summary>
    public class FXObjectPooler : MonoBehaviour
    {
        private static FXObjectPooler _instance;
        [SerializeField]
        private List<Pool> pools;
        private Dictionary<Effect, Queue<GameObject>> _poolDictionary;

        /// <summary>
        /// Instance to be called as singleton
        /// </summary>
        public static FXObjectPooler Instance => _instance;

        /// <summary>
        /// Spawn Particle effect from pooler
        /// </summary>
        /// <param name="tag">Which effect to spawn</param>
        /// <param name="position">where to spawn</param>
        /// <param name="rotation">rotation of spawn</param>
        /// <returns>Particle Effect Game Object</returns>
        public GameObject SpawnFromPool(Effect tag, Vector3 position, Quaternion rotation)
        {
            if (!this._poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning(tag + " does not exist");
                return null;
            }

            GameObject newObj = this._poolDictionary[tag].Dequeue();
            newObj.SetActive(true);
            newObj.transform.position = position;
            newObj.transform.rotation = rotation;
            newObj.GetComponent<ParticleSystem>().Play();

           this._poolDictionary[tag].Enqueue(newObj);

            return newObj;
        }

        private void Awake()
        {
            _instance = this;
        }

        // Use this for initialization
        private void Start()
        {
            this._poolDictionary = new Dictionary<Effect, Queue<GameObject>>();

            foreach (Pool pool in this.pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.Size; i++)
                {
                    if (pool.Prefab.GetComponent<ParticleSystem>() == null)
                    {
                        throw new System.Exception("SHOULD HAVE A PARTICLE SYSTEM");
                    }

                    GameObject obj = Instantiate(pool.Prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                    obj.transform.parent = this.transform;
                }

                this._poolDictionary.Add(pool.Tag, objectPool);
            }
        }

        public Effect GetMediumExplosionFromPlayer(Player player)
        {
            switch (player)
            {
                case Player.PLAYER_ONE:
                    return Effect.Medium_Red_Explosion;
                case Player.PLAYER_TWO:
                    return Effect.Medium_Blue_Explosion;
                case Player.PLAYER_THREE:
                    return Effect.Medium_Green_Explosion;
                case Player.PLAYER_FOUR:
                    return Effect.Medium_Yellow_Explosion;
                default:
                    return Effect.Default_Explosion;
            }
        }
    }

    /// <summary>
    /// Struct of pool for inspector to add elements to
    /// </summary>
    [System.Serializable]
    public class Pool
    {
        [SerializeField]
        private Effect _tag;
        [SerializeField]
        private GameObject _prefab;
        [SerializeField]
        private int _size;

        /// <summary>
        /// Effect enum
        /// </summary>
        public Effect Tag => this._tag;

        /// <summary>
        /// Prefab of particle effect
        /// </summary>
        public GameObject Prefab => this._prefab;

        /// <summary>
        /// How many to instantiate
        /// </summary>
        public int Size => this._size;
    }
}
