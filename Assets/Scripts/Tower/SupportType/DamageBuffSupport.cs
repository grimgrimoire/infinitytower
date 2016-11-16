using UnityEngine;
using System.Collections;
using System;

public class DamageBuffSupport : SupportInterface
{

    public void ProjectileSupport(GameObject projectilePool)
    {
    }

    public void RemoveProjectileSupport(GameObject projectilePool)
    {
    }

    public void ApplyArtillerySupport(ArtilleryModel model)
    {
        if (model != null)
            model.damage *= 2;
    }

    public void RemoveArtillerySupport(ArtilleryModel model)
    {
        if (model != null)
            model.damage /= 2;
    }
}
