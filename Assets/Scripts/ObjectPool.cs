using UnityEngine;
using System.Collections;

public class ObjectPool:MonoBehaviour {

    string peon1 = "Prefab/Assassin";
    string peon2 = "Prefab/Bat";
    string peon3 = "Prefab/Spider";
    string peon4 = "Prefab/Ninja";
    string peon5 = "Prefab/Soldier";

    PoolClass peon1Pool;
    PoolClass peon2Pool;
    PoolClass peon3Pool;

    public IEnumerator InitiatePooling()
    {
        peon1Pool = new PoolClass(peon1, 110);
        peon2Pool = new PoolClass(peon2, 1);
        peon3Pool = new PoolClass(peon3, 1);
        yield return peon1Pool.InitiatePooling();
        yield return peon2Pool.InitiatePooling();
        yield return peon3Pool.InitiatePooling();
        yield return new WaitForEndOfFrame();
    }

    public GameObject GetAssassin()
    {
        return peon1Pool.GetFromPool();
    }

    public GameObject GetBat()
    {
        return peon2Pool.GetFromPool() ;
    }

    public GameObject GetSpider()
    {
        return peon3Pool.GetFromPool();
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
