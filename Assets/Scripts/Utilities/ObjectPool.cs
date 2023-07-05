using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject poolObjectPrefab;
    [SerializeField] private int poolSize;
    
    private Queue<GameObject> poolQueue;

    private void Awake()
    {
        poolQueue = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject poolObject = Instantiate(poolObjectPrefab);

            poolObject.SetActive(false);

            poolQueue.Enqueue(poolObject);
        }

    }

    public GameObject GetPooledObject()
    {
        GameObject poolObject = poolQueue.Dequeue();

        poolObject.SetActive(true);

        poolQueue.Enqueue(poolObject);

        return poolObject;
    }
}
