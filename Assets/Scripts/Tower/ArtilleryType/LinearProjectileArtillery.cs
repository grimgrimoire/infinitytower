using UnityEngine;
using System.Collections;
using System;

public class LinearProjectileArtillery : ArtilleryInterface
{
    ArtilleryModel model;
    int poolIndex;
    int counter;
    int projectileSpeed = 5;

    public LinearProjectileArtillery(ArtilleryModel model)
    {
        this.model = model;
    }

    public LinearProjectileArtillery(ArtilleryModel model, int projectileSpeed)
    {
        this.model = model;
        this.projectileSpeed = projectileSpeed;
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        counter = 0;
        while (projectilePrefab[poolIndex].activeSelf && counter < model.poolSize)
        {
            poolIndex = (poolIndex + 1) % model.poolSize;
            counter++;
        }
        projectilePrefab[poolIndex].SetActive(true);
        projectilePrefab[poolIndex].transform.position = artillery.transform.position;
        projectilePrefab[poolIndex].GetComponent<ArtilleryProjectile>().SetSpeed(projectileSpeed)
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target.transform.position);
        poolIndex = (poolIndex + 1) % model.poolSize;
        yield return null;
    }
}
