using UnityEngine;
using System.Collections;

public class RocketArtillery : ArtilleryInterface {

    ArtilleryModel model;
    int poolIndex;
    int counter;

    public RocketArtillery(ArtilleryModel model)
    {
        this.model = model;
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        ShootRocket(target, artillery, projectilePrefab);
        yield return new WaitForSeconds(0.5f);
        ShootRocket(target, artillery, projectilePrefab);
        yield return new WaitForSeconds(0.5f);
        ShootRocket(target, artillery, projectilePrefab);
    }

    private void ShootRocket(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        counter = 0;
        while (projectilePrefab[poolIndex].activeSelf && counter < model.poolSize)
        {
            poolIndex = (poolIndex + 1) % model.poolSize;
            counter++;
        }
        projectilePrefab[poolIndex].SetActive(true);
        projectilePrefab[poolIndex].transform.position = artillery.transform.position;
        projectilePrefab[poolIndex].GetComponent<RocketProjectile>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target);
        poolIndex = (poolIndex + 1) % model.poolSize;
    }
}
