using UnityEngine;
using System.Collections;

public class ObjectPool:MonoBehaviour {

    string peon1 = "Prefab/Assassin";
    string peon2 = "Prefab/Bat";

    GameObject[] peon1Pool;
    GameObject[] peon2Pool;

    int peon1Index = 0;
    int peon2Index = 0;

    int prefabNumber = 100;

    public IEnumerator InitiatePooling()
    {
        InstantiatePooling(ref peon1Pool, prefabNumber, peon1);
        InstantiatePooling(ref peon2Pool, prefabNumber, peon2);
        yield return new WaitForEndOfFrame();
    }

    public GameObject GetPeon1()
    {
        int initialIndex = peon1Index;
        while (peon1Pool[peon1Index].activeInHierarchy)
        {
            peon1Index = (peon1Index + 1) % prefabNumber;
            if (peon1Index == initialIndex)
            {
                return null;
            }
        }
        return peon1Pool[peon1Index];
    }

    private void InstantiatePooling(ref GameObject[] arrayPool, int totalObject, string prefabName)
    {
        GameObject enemyPrefab = Resources.Load(prefabName, typeof(GameObject)) as GameObject;
        arrayPool = new GameObject[totalObject];
        for (int i = 0; i < totalObject; i++)
        {
            arrayPool[i] = Instantiate(enemyPrefab);
            arrayPool[i].transform.position = new Vector2(transform.position.x, -10);
        }
    }

}
