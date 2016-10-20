using UnityEngine;
using System.Collections;
using System;

public class CannonArtillery : ArtilleryInterface
{

    ArtilleryModel model;

    public CannonArtillery(ArtilleryModel model)
    {
        this.model = model;
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject projectilePrefab)
    {
        projectilePrefab.SetActive(true);
        projectilePrefab.transform.position = artillery.transform.position;
        projectilePrefab.GetComponent<ArtilleryExplosive>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target.transform.position);
        yield return null;
    }
}
