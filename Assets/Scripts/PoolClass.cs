using UnityEngine;
using System.Collections;

public class PoolClass {

    string prefabName;
    GameObject[] poolArray;
    int poolSize;
    int poolIndex = 0;

    public PoolClass(string prefabName, int size)
    {
        this.prefabName = prefabName;
        this.poolSize = size;
    }

    public GameObject GetFromPool()
    {
        int initialIndex = poolIndex;
        poolIndex = (poolIndex + 1) % poolSize;
        while (poolArray[poolIndex].activeSelf)
        {
            poolIndex = (poolIndex + 1) % poolSize;
            if (poolIndex == initialIndex)
            {
                return null;
            }
        }
        return poolArray[poolIndex];
    }

    public IEnumerator InitiatePooling()
    {
        GameObject enemyPrefab = Resources.Load(prefabName, typeof(GameObject)) as GameObject;
        poolArray = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            poolArray[i] = GameObject.Instantiate(enemyPrefab);
        }
        yield return null;
    }
}
