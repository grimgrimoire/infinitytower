using UnityEngine;
using System.Collections;

public class ObjectPool : MonoBehaviour
{

    string peon1 = "Prefab/EnemyUnit/Assassin";
    string peon2 = "Prefab/EnemyUnit/Bat";
    string peon3 = "Prefab/EnemyUnit/Spider";
    string peon4 = "Prefab/EnemyUnit/Ninja";
    string peon5 = "Prefab/EnemyUnit/Soldier";
    string peon6 = "Prefab/EnemyUnit/Air_Balloon";
    string peon7 = "Prefab/EnemyUnit/Zapelin";
    string elite1 = "Prefab/EnemyUnit/Wyvern";
    string elite2 = "Prefab/EnemyUnit/EliteKnight";
    string peon8 = "Prefab/EnemyUnit/SoldierShield";
    string peon9 = "Prefab/EnemyUnit/SpiderLarge";
    string peon10 = "Prefab/EnemyUnit/SpiderMini";
    string peon11 = "Prefab/EnemyUnit/ZapelinLarge";
    string peon12 = "Prefab/EnemyUnit/MiniBalloon";

    string explosion = "Prefab/Projectile/Explosion";
    string blood = "Prefab/DeadEffect/Blood";
    string airExplode = "Prefab/DeadEffect/AirExplode";
    string guardmanex = "Prefab/Projectile/GuardmanExplosion";
    string secondaryArrow = "Prefab/Projectile/RangerArrowRain";
    string pirateScatter = "Prefab/Projectile/PirateScatter";
    string meteorEx = "Prefab/Projectile/MeteorExplosion";
    string poisonGas = "Prefab/Projectile/PoisonGas";
    string stunExplosion = "Prefab/Projectile/StunExplosion";
    string bloodL = "Prefab/DeadEffect/BloodLarge";
    string airExplodeL = "Prefab/DeadEffect/AirExplodeLarge";

    PoolClass peon1Pool;
    PoolClass peon2Pool;
    PoolClass peon3Pool;
    PoolClass peon4Pool;
    PoolClass peon5Pool;
    PoolClass peon6Pool;
    PoolClass peon7Pool;
    PoolClass peon8Pool;
    PoolClass peon9Pool;
    PoolClass peon10Pool;
    PoolClass peon11Pool;
    PoolClass peon12Pool;
    PoolClass explosionPool;
    PoolClass bloodPool;
    PoolClass airExPool;
    PoolClass guardmanPool;
    PoolClass arrowPool;
    PoolClass scatterPool;
    PoolClass meteorPool;
    PoolClass poisonPool;
    PoolClass stunExPool;
    PoolClass elite1Pool;
    PoolClass elite2Pool;
    PoolClass bloodLPool;
    PoolClass airExLPool;

    public IEnumerator InitiatePooling()
    {
        peon1Pool = new PoolClass(peon1, 100);
        peon2Pool = new PoolClass(peon2, 100);
        peon3Pool = new PoolClass(peon3, 100);
        peon4Pool = new PoolClass(peon4, 50);
        peon5Pool = new PoolClass(peon5, 30);
        peon6Pool = new PoolClass(peon6, 50);
        peon7Pool = new PoolClass(peon7, 30);
        peon8Pool = new PoolClass(peon8, 10);
        peon9Pool = new PoolClass(peon9, 6);
        peon10Pool = new PoolClass(peon10, 30);
        peon11Pool = new PoolClass(peon11, 6);
        peon12Pool = new PoolClass(peon12, 30);
        elite1Pool = new PoolClass(elite1, 5);
        elite2Pool = new PoolClass(elite2, 5);
        explosionPool = new PoolClass(explosion, 15);
        bloodPool = new PoolClass(blood, 20);
        scatterPool = new PoolClass(pirateScatter, 20);
        guardmanPool = new PoolClass(guardmanex, 100);
        arrowPool = new PoolClass(secondaryArrow, 100);
        meteorPool = new PoolClass(meteorEx, 10);
        poisonPool = new PoolClass(poisonGas, 15);
        airExPool = new PoolClass(airExplode, 20);
        stunExPool = new PoolClass(stunExplosion, 15);
        airExLPool = new PoolClass(airExplodeL, 15);
        bloodLPool = new PoolClass(bloodL, 10);
        yield return peon1Pool.InitiatePooling();
        yield return peon2Pool.InitiatePooling();
        yield return peon3Pool.InitiatePooling();
        yield return peon4Pool.InitiatePooling();
        yield return peon5Pool.InitiatePooling();
        yield return peon6Pool.InitiatePooling();
        yield return peon7Pool.InitiatePooling();
        yield return peon8Pool.InitiatePooling();
        yield return explosionPool.InitiatePooling();
        yield return bloodPool.InitiatePooling();
        yield return airExPool.InitiatePooling();
        yield return guardmanPool.InitiatePooling();
        yield return arrowPool.InitiatePooling();
        yield return stunExPool.InitiatePooling();
        yield return scatterPool.InitiatePooling();
        yield return meteorPool.InitiatePooling();
        yield return poisonPool.InitiatePooling();
        yield return elite1Pool.InitiatePooling();
        yield return elite2Pool.InitiatePooling();
        yield return peon9Pool.InitiatePooling();
        yield return peon10Pool.InitiatePooling();
        yield return peon11Pool.InitiatePooling();
        yield return peon12Pool.InitiatePooling();
        yield return bloodLPool.InitiatePooling();
        yield return airExLPool.InitiatePooling();
        yield return new WaitForEndOfFrame();
    }

    public GameObject GetBloodLarge()
    {
        return bloodLPool.GetFromPool();
    }

    public GameObject GetAirExLarge()
    {
        return airExLPool.GetFromPool();
    }

    public GameObject GetStunExp()
    {
        return stunExPool.GetFromPool();
    }

    public GameObject GetZeppelinLarge()
    {
        return peon11Pool.GetFromPool();
    }

    public GameObject GetMiniBalloon()
    {
        return peon12Pool.GetFromPool();
    }

    public GameObject GetLargeSpider()
    {
        return peon9Pool.GetFromPool();
    }

    public GameObject GetMiniSpider()
    {
        return peon10Pool.GetFromPool();
    }

    public GameObject GetShield()
    {
        return peon8Pool.GetFromPool();
    }

    public GameObject GetNinja()
    {
        return peon4Pool.GetFromPool();
    }

    public GameObject GetDragon()
    {
        return elite1Pool.GetFromPool();
    }

    public GameObject GetKnight()
    {
        return elite2Pool.GetFromPool();
    }

    public GameObject GetBalloon()
    {
        return peon6Pool.GetFromPool();
    }

    public GameObject GetPoisonGas()
    {
        return poisonPool.GetFromPool();
    }

    public GameObject GetMeteorExplosion()
    {
        return meteorPool.GetFromPool();
    }

    public GameObject GetScatter()
    {
        return scatterPool.GetFromPool();
    }

    public GameObject GetAssassin()
    {
        return peon1Pool.GetFromPool();
    }

    public GameObject GetSoldier()
    {
        return peon5Pool.GetFromPool();
    }

    public GameObject GetAirDeath()
    {
        return airExPool.GetFromPool();
    }

    public GameObject GetBat()
    {
        return peon2Pool.GetFromPool();
    }

    public GameObject GetZeppelin()
    {
        return peon7Pool.GetFromPool();
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
            if (index == initialIndex)
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
