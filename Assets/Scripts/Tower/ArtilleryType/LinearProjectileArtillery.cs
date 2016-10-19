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

    public void ShootAtTarget(GameObject target, GameObject artillery, GameObject projectilePrefab)
    {
        GameObject bullet = GameObject.Instantiate(projectilePrefab);
        bullet.transform.position = artillery.transform.position;
        bullet.GetComponent<ArtilleryProjectile>()
            .SetDamageType(model.damage, model.damageType)
            .SetTarget(target.transform.position);
    }
}
