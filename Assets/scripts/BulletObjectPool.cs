using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjectPool : MonoBehaviour
{
    public static BulletObjectPool sharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectPool;
    public int amountToPool;

    private void Awake()
    {
        sharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject getPooledObjects()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
                return pooledObjects[i];
        }
        return null;
    }

  
}
