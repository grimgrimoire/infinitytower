using UnityEngine;
using System.Collections;
using System;

public class FollowedArrow : ArtilleryInterface
{

    ArtilleryModel model;
    int poolIndex;
    int counter;
    int repeatCount;

    public FollowedArrow(ArtilleryModel model, int repeat)
    {
        this.model = model;
        repeatCount = repeat;
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        for (int i = 1; i <= repeatCount; i++)
        {
            Shoot(target, artillery, projectilePrefab);
            if (i < repeatCount)
                yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }

    private void Shoot(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        counter = 0;
        while (projectilePrefab[poolIndex].activeSelf && counter < model.poolSize)
        {
            poolIndex = (poolIndex + 1) % model.poolSize;
            counter++;
        }
        projectilePrefab[poolIndex].SetActive(true);
        projectilePrefab[poolIndex].transform.position = artillery.transform.position;
        projectilePrefab[poolIndex].GetComponent<ArtilleryProjectile>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target.transform.position);
        poolIndex = (poolIndex + 1) % 5;
    }
}
