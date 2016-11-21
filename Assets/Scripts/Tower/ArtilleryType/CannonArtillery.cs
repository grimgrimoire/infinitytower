using UnityEngine;
using System.Collections;
using System;

public class CannonTargeting : ArtilleryTargetingInterface
{
    public bool CheckPriorityCondition(GameObject currentTarget, GameObject hostiles, GameObject self)
    {
        if (hostiles.GetComponent<HostileMainScript>().isGroundUnit) {
            if (currentTarget == null || !currentTarget.activeSelf)
                return true;
            else if (Vector2.Distance(self.transform.position, hostiles.transform.position) < Vector2.Distance(self.transform.position, currentTarget.transform.position))
                return true;
            else
                return false;
        }
        else
            return false;
    }
}

public class CannonArtillery : ArtilleryInterface
{

    ArtilleryModel model;
    int poolIndex;
    int counter;

    public CannonArtillery(ArtilleryModel model)
    {
        this.model = model;
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject[] projectilePrefab)
    {
        counter = 0;
        while (projectilePrefab[poolIndex].activeSelf && counter < 5)
        {
            poolIndex = (poolIndex + 1) % 5;
            counter++;
        }
        projectilePrefab[poolIndex].SetActive(true);
        projectilePrefab[poolIndex].transform.position = artillery.transform.position;
        projectilePrefab[poolIndex].GetComponent<ArtilleryExplosive>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target.transform.position);
        poolIndex = (poolIndex + 1) % 5;
        yield return null;
    }
}
