using UnityEngine;
using System.Collections;
using System;

public class LinearProjectileArtillery : ArtilleryInterface
{
    ArtilleryModel model;

    public LinearProjectileArtillery(ArtilleryModel model)
    {
        this.model = model;
    }

    IEnumerator ArtilleryInterface.ShootAtTarget(GameObject target, GameObject artillery, GameObject projectilePrefab)
    {
        projectilePrefab.SetActive(true);
        projectilePrefab.transform.position = artillery.transform.position;
        projectilePrefab.GetComponent<ArtilleryProjectile>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target.transform.position);
        yield return null;
    }
}
