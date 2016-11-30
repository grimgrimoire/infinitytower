using UnityEngine;
using System.Collections;

public class ObjectPool:MonoBehaviour {

    string peon1 = "Prefab/EnemyUnit/Assassin";
    string peon2 = "Prefab/EnemyUnit/Bat";
    string peon3 = "Prefab/EnemyUnit/Spider";
    string peon4 = "Prefab/EnemyUnit/Ninja";
    string peon5 = "Prefab/EnemyUnit/Soldier";
    string peon6 = "Prefab/EnemyUnit/Air_Balloon";
    string peon7 = "Prefab/EnemyUnit/Zapelin";

    string explosion = "Prefab/Projectile/Explosion";
    string blood = "Prefab/DeadEffect/Blood";
    string guardmanex = "Prefab/Projectile/GuardmanExplosion";
    string secondaryArrow = "Prefab/Projectile/RangerArrowRain";
    string pirateScatter = "Prefab/Projectile/PirateScatter";

    PoolClass peon1Pool;
    PoolClass peon2Pool;
    PoolClass peon3Pool;
    PoolClass peon4Pool;
    PoolClass peon5Pool;
    PoolClass peon6Pool;
    PoolClass peon7Pool;
    PoolClass explosionPool;
    PoolClass bloodPool;
    PoolClass guardmanPool;
    PoolClass arrowPool;
    PoolClass scatterPool;

    public IEnumerator InitiatePooling()
    {
        peon1Pool = new PoolClass(peon1, 100);
        peon2Pool = new PoolClass(peon2, 100);
        peon3Pool = new PoolClass(peon3, 100);
        peon4Pool = new PoolClass(peon4, 50);
        peon5Pool = new PoolClass(peon5, 30);
        peon6Pool = new PoolClass(peon6, 50);
        peon7Pool = new PoolClass(peon7, 30);
        explosionPool = new PoolClass(explosion, 15);
        bloodPool = new PoolClass(blood, 20);
        scatterPool = new PoolClass(pirateScatter, 20);
        guardmanPool = new PoolClass(guardmanex, 25);
        arrowPool = new PoolClass(secondaryArrow, 100);
        yield return peon1Pool.InitiatePooling();
        yield return peon2Pool.InitiatePooling();
        yield return peon3Pool.InitiatePooling();
        yield return peon4Pool.InitiatePooling();
        yield return peon5Pool.InitiatePooling();
        yield return peon6Pool.InitiatePooling();
        yield return peon7Pool.InitiatePooling();
        yield return explosionPool.InitiatePooling();
        yield return bloodPool.InitiatePooling();
        yield return guardmanPool.InitiatePooling();
        yield return arrowPool.InitiatePooling();
        yield return scatterPool.InitiatePooling();
        yield return new WaitForEndOfFrame();
    }

    public GameObject GetScatter()
    {
        return scatterPool.GetFromPool();
    }

    public GameObject GetAssassin()
    {
        return peon1Pool.GetFromPool();
    }

    public GameObject GetBat()
    {
        return peon2Pool.GetFromPool() ;
    }

    public GameObject GetArrow()
    {
        return arrowPool.GetFromPool();
    }

    public GameObject GetSpider()
    {
        return peon3Pool.GetFromPool();
    }

    public GameObject GetGuardmanEx()
    {
        return guardmanPool.GetFromPool();
    }

    public GameObject GetExplosion()
    {
        return explosionPool.GetFromPool();
    }

    public GameObject GetBlood()
    {
        return bloodPool.GetFromPool();
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

    public static ObjectPool GetInstance()
    {
        return GameSystem.GetGameSystem().GetObjectPool();
    }

}
