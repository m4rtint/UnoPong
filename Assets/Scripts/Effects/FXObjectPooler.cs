namespace MPHT
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class FXObjectPooler : MonoBehaviour
    {
        [SerializeField]
        private List<Pool> pools;
        private Dictionary<Effect, Queue<GameObject>> poolDictionary;


        [System.Serializable]
        public class Pool
        {
            public Effect tag;
            public GameObject prefab;
            public int size;
        }

        #region Singleton
        public static FXObjectPooler Instance;

        private void Awake()
        {
            Instance = this;
        }
        #endregion Singleton

        // Use this for initialization
        void Start()
        {
            poolDictionary = new Dictionary<Effect, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    if (pool.prefab.GetComponent<ParticleSystem>() == null)
                    {
                        throw new System.Exception("SHOULD HAVE A PARTICLE SYSTEM");
                    }

                    GameObject obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                    obj.transform.parent = transform;
                }

                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(Effect tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning(tag + " does not exist");
                return null;
            }

            GameObject newObj = poolDictionary[tag].Dequeue();
            newObj.SetActive(true);
            newObj.transform.position = position;
            newObj.transform.rotation = rotation;
            newObj.GetComponent<ParticleSystem>().Play();

            poolDictionary[tag].Enqueue(newObj);

            return newObj;
        }
    }

    public enum Effect
    {
        Blue_Brick_Break
    }
}
