using UnityEngine;
using System.Collections;

public class ObjectPool:MonoBehaviour {

    string peon1 = "Prefab/Assassin";
    string peon2 = "Prefab/Bat";

    GameObject[] peon1Pool;
    GameObject[] peon2Pool;

    int peon1Index = 0;
    int peon2Index = 0;

    int poolSize = 100;

    public IEnumerator InitiatePooling()
    {
        InstantiatePooling(ref peon1Pool, poolSize, peon1);
        InstantiatePooling(ref peon2Pool, poolSize, peon2);
        yield return new WaitForEndOfFrame();
    }

    public GameObject GetPeon1()
    {
        return GetObjectFromPool(ref peon1Index, peon1Pool, poolSize);
    }

    public GameObject GetPeon2()
    {
        return GetObjectFromPool(ref peon2Index, peon2Pool, poolSize);
    }

    private GameObject GetObjectFromPool(ref int index, GameObject[] poolArray, int poolSize)
    {
        int initialIndex = index;
        while (poolArray[index].activeSelf)
        {
            index = (index + 1) % poolSize;
            if(index == initialIndex)
            {
                return null;
            }
        }
        return poolArray[index];
    }

    private void InstantiatePooling(ref GameObject[] arrayPool, int totalObject, string prefabName)
    {
        GameObject enemyPrefab = Resources.Load(prefabName, typeof(GameObject)) as GameObject;
        arrayPool = new GameObject[totalObject];
        for (int i = 0; i < totalObject; i++)
        {
            arrayPool[i] = Instantiate(enemyPrefab);
        }
    }

}
