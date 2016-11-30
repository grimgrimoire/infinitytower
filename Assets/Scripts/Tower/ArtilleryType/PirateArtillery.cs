using UnityEngine;
using System.Collections;
using System;

public class PirateArtillery : ArtilleryInterface {

    ArtilleryModel model;
    int poolIndex;
    int counter;

    public PirateArtillery(ArtilleryModel model)
    {
        this.model = model;
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
        projectilePrefab[poolIndex].GetComponent<PirateProjectile>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target.transform.position);
        poolIndex = (poolIndex + 1) % model.poolSize;
        yield return null;
    }
}
